using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;//����ũ ������



   // Start is called before the first frame update
   private void OnCollisionEnter(Collision collision)
        //�浹�� �߻��� ��� �߿��� BULLET �±׸� ����
    {
        if (collision.collider.tag=="BULLET")

        {
            //����ũ ����Ʈ �Լ� ȣ��
            ShowEffect(collision);

            //�浹�� �߻��� ������Ʈ ����
            //Destroy(collision.gameObject);//�׿��� �� �ٷ� �������� �ڵ�
            //Destroy(collision.gameObject,5f); //�׿��� �� ������ �������� �ڵ�
            collision.gameObject.SetActive(false);
        }
    }

    void ShowEffect(Collision coll)

    {
        //�浹 ������ ������ ������ ��
        //�浹 �� �߻��� ������ ��ġ ����
        ContactPoint contact = coll.contacts[0];
        //FromToRotation(ȸ�� ��Ű���� �ϴ� ����, Ÿ�� ����)�ܹ��� ��Ʈ �޴�~~~(������)
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, contact.normal);
        //�浹�� �� �� ����Ʈ�� ȿ�� ���� (z)��
        //���� ���� (�Ѿ��� ���ƿ� ���� -z)�������� ������ ������
        //�Ѿ��� �߻�� ��ġ�� �̵�(�巳�뿡�� ���� �� �Ѿ� �ڱ� ����)
        Vector3 point = contact.point + (-contact.normal * 0.05f);
        GameObject spark = Instantiate(sparkEffect, contact.point, rot); Instantiate(sparkEffect, contact.point, rot);
        //���� ������ ����Ʈ�� �θ�� �巳���� ����
        spark.transform.SetParent(this.transform);
    }
}