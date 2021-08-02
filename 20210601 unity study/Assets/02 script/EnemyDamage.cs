using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    float iniHp = 100f;//�ʱ� ���� ü��

    public GameObject hpBarPrefab;
    public Vector3 hpBaroffset = new Vector3(0, 2.2f, 0);
    Canvas uiCanvas;//�θ� �� ĵ���� ��ü
    Image hpBarImage;//����� ��ġ

    const string bulletTag = "BULLET";

    float hp = 100f;//ü��
    GameObject bloodEffect;//���� ȿ��

   
    void Start()
    {
        //Load �Լ��� ���� ������ Recources���� �����͸� �ҷ����� �Լ���
        //Load<������ ����>("������ ���")
        //�ֻ��� ��δ� Resources ������ ex)C����̺�
        //������ ��δ� ���� ������ + ���ϸ���� ��Ȯ�ϰ� Ǯ��θ� ���
        bloodEffect = Resources.Load<GameObject>("Blood");//��ġ ��Ȯ�� ����ϱ�
        //ü�¹� ���� �Լ� ȣ��
        SetHpBar();



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == bulletTag)
        {
            //���� ȿ�� �Լ� ȣ��
            ShowBloodEffect(collision);

            //�Ѿ� ����
            //Destroy(collision.gameObject);

            collision.gameObject.SetActive(false);
            hp -= collision.gameObject.GetComponent<Bulletctrl>().damage;//�Ѿ˸��� �������� �ٸ� ���� �ֱ� ������ �������� �־��ش�(Ư��źȯ)

            hpBarImage.fillAmount = hp / iniHp;

            //������ �ʿ� �������� �ֱ�
            //ü���� 0 ���ϰ� �Ǹ� ���� �׾��ٰ� �Ǵ�
            if (hp <= 0)//�� ���� ���� �� '==' �� ��
            {
                //���� ��ȭ ����
                GetComponent<EnemyAI>().state = EnemyAI.State.DIE;
                hpBarImage.GetComponentsInParent<Image>()[1].color = Color.clear;

                //싱글턴 패널을 활용하여 적이 죽었을 때 스코어 증가
                GameManager.instance.incKillCount();
                //죽은 애니메이션 이후 남아있는 콜라이더 비활성화
                GetComponent<CapsuleCollider>().enabled = false;


            }
        }
    }


    void SetHpBar()
    {
        uiCanvas = GameObject.Find("UICanvas").GetComponent<Canvas>();
        //uiCanvas�� �ڽ����� hpBar������ ���� ����
        GameObject hpBar = Instantiate(hpBarPrefab, uiCanvas.transform);
        hpBarImage = hpBar.GetComponentsInChildren<Image>()[1];

        var _hpBar = hpBar.GetComponent<EnemyHpBar_>();
        //_hpBar�� �����ؾ��� ������� Enemy ����
        _hpBar.targetTr = gameObject.transform;
        _hpBar.offset = hpBaroffset;




    }


    //�Ѿ� ���� ������ �ǰ� ������ �ϰڴٴ� �ǹ� 
    void ShowBloodEffect(Collision coll)
    {
        Vector3 pos = coll.contacts[0].point;
        //�浹 ��ġ�� ���� ��Ÿ(�Ѿ��� ����� ����)���ϱ�
        Vector3 _nomal = coll.contacts[0].normal;
        //�Ѿ��� ����� ���Ⱚ ���
        Quaternion rot = Quaternion.FromToRotation(Vector3.back, _nomal);
        GameObject blood = Instantiate<GameObject>(bloodEffect, pos, rot);
        //1�� �� ����
        Destroy(blood, 1f);
    }


    void Update()
    {
        
    }
}
