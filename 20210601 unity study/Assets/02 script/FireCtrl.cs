using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;//UI ���� �̺�Ʈ



[System.Serializable]//����ȭ �ν������� ǥ��



public struct PlayerSfx

    //����ü ���ÿ���
    //~~~~ ������

    //struct = ����ü Ŭ���� ��ȭ������ �����ϸ� ����
    //Ŭ������ ����ü ���� ������ ����
    //�׷��� ���ݿ� �ͼ��� �޸� ���� ������ ���̸� ���� ��
    //��ɻ��� ū ���� x
{
    public AudioClip[] fire;
    public AudioClip[] reload;

}


public class FireCtrl : MonoBehaviour
{
    public enum WeaponType
    {
        RIFLE = 0,
        SHOTGUN
    }
    public WeaponType currWeapon = WeaponType.RIFLE;




    public GameObject bullet;//�Ѿ� ������ ����ϱ� ���� ����
    public Transform firePos;//�Ѿ� �߻� ��ġ
    public ParticleSystem cartridge;//ź�� ������
    private ParticleSystem muzzleFlash;//�ѱ� ȭ�� ��ƼŬ

    AudioSource _audio;
    public PlayerSfx playerSfx; //����� Ŭ�� ���� ����

    Shake shake;

    public Image manazineImg;
    public Text magazineText;

    public int maxBullet = 10;//�ִ�  �Ѿ� ��
    public int remainingBullet = 10;//���� �Ѿ� ��

    public float reloadTime = 2f;//������ �ð�
    bool isReroading = false;

    public Sprite[] weaponIcons;//������ ���� �̹���
    public Image weaponImage;//��ü�� ���� �̹��� UI

    //자동공격을 위한 변수 선언
    int layerMask;//여러 레이어를 병합하여 사용할 레이어 마스크
    int obstacleLayer;
    int enemyLayer;

    bool isFire = false;
    float nextFire;
    public float fireRate = 0.1f;


    public void OnChangeWeapon()
    {
        currWeapon++;
        currWeapon = (WeaponType)((int)currWeapon % 2);
        weaponImage.sprite = weaponIcons[(int)currWeapon];
    }
    
    void Start()
    {
        muzzleFlash = firePos.GetComponentInChildren<ParticleSystem>();
        _audio = GetComponent<AudioSource>();
        shake = GameObject.Find("CameraRig").GetComponent<Shake>();

        //레이어의 이름을 통하여 레이어값 미리 설정
        enemyLayer=LayerMask.NameToLayer("ENEMY");
        obstacleLayer = LayerMask.NameToLayer("OBSTACLE");
        // 100 | 001 = 101
        //or 연산은 둘 다 0이 아닌 경우에 1로 처리함
        layerMask = 1 << enemyLayer | 1 << obstacleLayer;



    }

    void Update()
    {

        Debug.DrawLine(firePos.position, firePos.forward * 20f, Color.green); //실행 X
        
        //IsPointerOverGameObject: UI�� Ŭ���Ǹ� true�� ��ȯ�Ǵ� ��
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //자동공격
        RaycastHit hit;

        if (Physics.Raycast(firePos.position, firePos.forward, out hit, 20f, layerMask))
            //감지한 layerMask중에서 태그가 ENEMY인 경우만 공격
            isFire = (hit.collider.CompareTag("ENEMY"));
        else
            isFire = false;
        if(!isReroading && isFire)
        {
            if (Time.time > nextFire)
            {
                remainingBullet--;
                Fire();

                if (remainingBullet == 0)
                {
                    StartCoroutine(Reloading());
                }
                nextFire = Time.time + fireRate;
            }
        }
        
        //마우스 좌클릭 공격

        //0 �̸� ��Ŭ�� 1�̸� ��Ŭ��
        //GetMiuseButtonDown �Լ��� ������ �� 1���� ������
        if (!isReroading && Input.GetMouseButtonDown(0))
        {
            remainingBullet--;

            //�����Լ� ȣ��
            Fire();

            if (remainingBullet == 0)
            {
                //������ �ڷ�ƾ �Լ� ȣ��
                StartCoroutine(Reloading());

            }

        }

    }

    void Fire()
    {
        //shake ��ũ��Ʈ ������ ShakeCamera �ڷ�ƾ �Լ� ȣ��
        //�Ű����� ���� ���������Ƿ� ShakeCamera�Լ��� ������ �⺻������ ������
        StartCoroutine(shake.ShakeCamera());

        //Instantiate(���������� ������Ʈ, ��ġ, ����)
        //������ �ʴ� ��ü(Object)�� Ȱ��ȭ ���ִ� �Լ�
        //Instantiate(bullet, firePos.position, firePos.rotation);

        var _bullet = GameManager.instance.GetBullet();//������Ʈ Ǯ���� �Ѿ� �̾ƿ���
        if(_bullet != null)
        {
            _bullet.transform.position = firePos.position;
            _bullet.transform.rotation = firePos.rotation;
            _bullet.SetActive(true);
        }

        cartridge.Play();//ź�� ��ƼŬ ���
        muzzleFlash.Play();//�ѱ� ȭ�� ��ƼŬ ���

        FireSfx();//���ݽ� ���� �߻�

        manazineImg.fillAmount = (float)remainingBullet / (float)maxBullet;
        updateBulletText();
    }

    
    IEnumerator Reloading()
    {
        isReroading = true;
        _audio.PlayOneShot(playerSfx.reload[(int)currWeapon],1f);

        float audioLen = playerSfx.reload[(int)currWeapon].length + 0.3f;
        yield return new WaitForSeconds(audioLen);

        isReroading = false;
        manazineImg.fillAmount = 1f;
        remainingBullet = maxBullet;

        //������ �Լ� ȣ��
        updateBulletText();
    }

    void updateBulletText()
    {
        magazineText.text = string.Format("<color=#00ff00>{0}</color>/{1}", remainingBullet, maxBullet);//���� ���� ��
    }


    void FireSfx()
    {
        //���� ���õ� ������ �ѹ��� �´� ���带 �����ؼ� ������ ��
        var _sfx = playerSfx.fire[(int)currWeapon];
        //var: �ڿ� ���� ���� ����� ��������� �ٲ�(��Ÿ��)
        //���� ũ��� 0~1 ������ ��
        _audio.PlayOneShot(_sfx, 1f);
             //PlayOneShot: ���� ���� ����
             //Play: ���� ���� �Ұ���

    }





}
