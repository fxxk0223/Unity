using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
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
            //������ �ʿ� �������� �ֱ�
            //ü���� 0 ���ϰ� �Ǹ� ���� �׾��ٰ� �Ǵ�
            if(hp<=0)//�� ���� ���� �� '==' �� ��
            {
                //���� ��ȭ ����
                GetComponent<EnemyAI>().state = EnemyAI.State.DIE;
            }
        }
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
