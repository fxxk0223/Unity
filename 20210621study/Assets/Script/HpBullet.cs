using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBullet : MonoBehaviour
{
    float speed = 3f;
    Rigidbody bulletRigidbody;
    public Vector3 moveDir = Vector3.zero;
    GameManager gm;
    //�Ѿ��� ó������ ����ȭ�鿡 �������� �ʱ⿡
    //���� ȭ�鿡 �����ϴ� ����� public������ �Է� ���� ä�� ������ �� ����
    //�Ѿ��� �ٸ� ������ ������ ���� �ֱ⿡
    //���� �����Ϳ��� ����� �־��ִ� ���� �ƴ�
    //��ũ��Ʈ���� �ɵ������� �ش� ����� ã�Ƽ� ������ �� �ֵ��� �ؾ��Ѵ�

    void Start()
    {
        bulletRigidbody = this.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = this.transform.forward * 10;
        //Vector3.forward;
        //���� ���� ��Ÿ���ִ� Vector3.forward~ ������ ��������
        //���Ӿ��� �������� �ϴ� ������ �ʴ� ���Ⱚ�̱� ������
        //�����̴� ����� ����ֵ�, ��� ������ ���ϵ�. ������ �ڽ����� �ֵ�
        //�׻� �Ȱ��� �������� �̵��ϰ� �ȴ�

        //this.transform.forward;
        //Vector3���� ���Ⱚ�� �������� �Ǹ�
        //��� ��Ȳ���� ������ �ʴ� ������ �������� ������ ������
        //Ư���� ���ӿ�����Ʈ�� ���� ������ �������� �Ǹ�
        //�ش� ����� �ٶ󺸴� ������ �������� �Ͽ� �յڻ����¿찡 �����ȴ�
        //��� ��쿡�� ���Ѿ��� ������ �ƴ� 
        //����� ��� �ٶ󺸴��Ŀ� ���� �� ������ ���������� ���ϴ� ����� ������ �ȴ�

        Destroy(this.gameObject, 10f);
        //Destroy�Լ��� �Ű������� ��� ������Ʈ�� �ð��� �ְ� �Ǹ�
        //�ش� �ð��� ������ �ڵ����� ������ �ȴ�

        GameObject target = GameObject.Find("gManager");
        if (target != null)
        {
            gm = target.GetComponent<GameManager>();
        }

        //Find�Լ��� ������ �̸��� ������ ����� �������� ������
        //null�� ��ȯ�ϱ⿡ ����� ������ ���� �ڵ尡 �����ϵ��� ���ǹ��� ���� �������ش�

        //GameObject.Find("��� �̸�")
        //�ش� �̸��� ���� ���� ������Ʈ�� ���Ӿ����� ã�Ƽ� ��ȯ���ִ� �Լ�
    }

    void Update()
    {

    }

    //����� collider�� �ٸ� ���� �ε����� ��(Enter)
    //��� �ִµ��� ���(Stay)
    //��Ҵ� ���� ������ ��(Exit)
    //�ڵ����� ����Ǵ� �Լ�
    //�ٸ� ���� �ε����� �� �� �� �ϳ��� is Trigger�� ����������
    //�ٸ� isTrigger�� �ƴϵ� ������� Trigger �Լ��� ȣ���� �ȴ�
    //Trigger�� üũ�� �ݶ��̴��� �ٸ� ���� �浹�� ������ �������� ������ �߻����� �ʴ´�(ƨ�� ������ �ʰ� ����Ѵ�)
    // private void OnCollisionEnter(Collision other)

    // Destroy(this.gameObject);
    //Destroy�Լ�: �Ű������� ���� ���� ����� �������ִ� �Լ�

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            //Destroy�Լ�: �Ű������� ���� ���� ����� �������ִ� �Լ�
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerCtrl player = other.gameObject.GetComponent<PlayerCtrl>();
            player.hp += 1;
            //����Ƽ���� �⺻������ �����Ǵ� ������Ʈ �Ӹ��� �ƴ϶�
            //����ڰ� ���� ��ũ��Ʈ ���� ������Ʈ�� ����� �ȴ�
            //���� GetComponent �� ��ũ��Ʈ�� ������ ���ִ�
            //��ũ��Ʈ �󿡼� ����� ������ �����Ϸ���
            //�ش� ��ũ��Ʈ�� ���� ���ӿ�����Ʈ���Լ� GetComponent �� �ش� ��ũ��Ʈ�� �����;� ������ �� �ִ�


            if (player.hp <= 0)
            {
                player.Die();
                gm.gameOver();
            }


            //��ũ��Ʈ �󿡼� Ư�� ����� �����ϴ� �ڵ尡 �����Ѵٸ�
            //�ش� �ڵ�� �ݵ�� ���� �������� ���� ���Ѿ� �Ѵ�
            //������ ������κ��� �����ϴ� �ڵ尡 �����Ѵٸ�
            //�ش� �ڵ��� ������ ���������� �̷����� ����  �� �ֱ�  ����
           

        }
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Wall")
            Destroy(this.gameObject);
    }
}
