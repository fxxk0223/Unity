using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject laserEff;
    //�������� ���� �ε����� �� �ε����� ȿ���� ��Ÿ���� �ִϸ��̼� ������Ʈ

    Vector3 dir = Vector3.up;//�������� ���ư����� ���� ���� �����ϴ� ����

    string targetTag = "enemy";//�������� �浹�� ����� �±װ� //�ʱⰪ�� enemy

    public void setTargetTag(string str)
    {
        targetTag = str;
    }
    
    void Start()
    {
        
        Destroy(this.gameObject,5.0f);
    }

    void Update()
    {
        this.transform.position += this.transform.up*Time.deltaTime*3;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag==targetTag)
        {
            //����� �ε�����

            Vector2 contactPoint = collision.ClosestPoint(this.transform.position);
            //�ݶ��̴� ���� �浹�� �Ͼ�� ��
            //�浹�� ������ ��ǥ�� ��ȯ���ִ� �Լ�
            //�ڵ� �ܿ��

            GameObject eff = Instantiate(laserEff, transform.position, Quaternion.identity);
            Destroy(eff, 0.2f);


            if (collision.tag == "Player")
            {
                collision.GetComponent<PlayerCtrl>().damaged();
            }
            else
            {
                Destroy(collision.gameObject);//������ ����
            }
            Destroy(this.gameObject);//�Ѿ˵� ����
        }
       
    }
    

}
