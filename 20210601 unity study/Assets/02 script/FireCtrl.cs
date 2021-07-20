using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;//UI 관련 이벤트



[System.Serializable]//직렬화 인스펙터의 표시



public struct PlayerSfx

    //구조체 스택영역
    //~~~~ 힙영역

    //struct = 구조체 클래스 열화판으로 생각하면 편함
    //클래스는 구조체 이후 등장한 개념
    //그러나 지금에 와서는 메모리 적재 형태의 차이만 있을 뿐
    //기능상의 큰 차이 x
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




    public GameObject bullet;//총알 프리팹 사용하기 위한 변수
    public Transform firePos;//총알 발사 위치
    public ParticleSystem cartridge;//탄피 프리팹
    private ParticleSystem muzzleFlash;//총구 화염 파티클

    AudioSource _audio;
    public PlayerSfx playerSfx; //오디오 클릭 저장 변수

    Shake shake;

    public Image manazineImg;
    public Text magazineText;

    public int maxBullet = 10;//최대  총알 수
    public int remainingBullet = 10;//남은 총알 수

    public float reloadTime = 2f;//재장전 시간
    bool isReroading = false;

    public Sprite[] weaponIcons;//변경할 무기 이미지
    public Image weaponImage;//교체할 무기 이미지 UI

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
    }

    void Update()
    {
        //IsPointerOverGameObject: UI가 클릭되면 true가 반환되는 놈
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        //0 이면 좌클릭 1이면 우클릭
        //GetMiuseButtonDown 함수는 눌렀을 때 1번만 동작함
        if (!isReroading && Input.GetMouseButtonDown(0))
        {
            remainingBullet--;

            //공격함수 호출
            Fire();

            if (remainingBullet == 0)
            {
                //재장전 코루틴 함수 호출
                StartCoroutine(Reloading());

            }

        }

    }

    void Fire()
    {
        //shake 스크립트 내부의 ShakeCamera 코루틴 함수 호출
        //매개변수 값을 생략했으므로 ShakeCamera함수에 설정된 기본값으로 동작함
        StartCoroutine(shake.ShakeCamera());

        //Instantiate(동적생성할 오브젝트, 위치, 방향)
        //사용되지 않는 객체(Object)를 활성화 해주는 함수
        //Instantiate(bullet, firePos.position, firePos.rotation);

        var _bullet = GameManager.instance.GetBullet();//오브젝트 풀에서 총알 뽑아오기
        if(_bullet != null)
        {
            _bullet.transform.position = firePos.position;
            _bullet.transform.rotation = firePos.rotation;
            _bullet.SetActive(true);
        }

        cartridge.Play();//탄피 파티클 재생
        muzzleFlash.Play();//총구 화염 파티클 재생

        FireSfx();//공격시 사운드 발생

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

        //재장전 함수 호출
        updateBulletText();
    }

    void updateBulletText()
    {
        magazineText.text = string.Format("<color=#00ff00>{0}</color>/{1}", remainingBullet, maxBullet);//존나 많이 씀
    }


    void FireSfx()
    {
        //현재 선택된 무기의 넘버에 맞는 사운드를 선택해서 가지고 옴
        var _sfx = playerSfx.fire[(int)currWeapon];
        //var: 뒤에 값에 따라 모양이 자유자재로 바뀜(메타몽)
        //볼륨 크기는 0~1 사이의 값
        _audio.PlayOneShot(_sfx, 1f);
             //PlayOneShot: 볼륨 조절 가능
             //Play: 볼륨 조절 불가능

    }





}
