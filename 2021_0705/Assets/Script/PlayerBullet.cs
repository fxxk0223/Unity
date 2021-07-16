using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    Vector3 dir = Vector3.right;//�Ѿ��� ���ư� ���Ⱚ
    string targetTag = "Enemy";//�Ѿ��� �浹�� ���
    void Start()
    {
        Destroy(this.gameObject, 5.0f);//�Ѿ��� �߻� ���� �� 5�� �� �Ѿ��� �����Ѵ�
    }

    void Update()
    {
        this.transform.position += this.transform.right * Time.deltaTime * 3;//�Ѿ��� ���������� ���ư��� �Ѵ�
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            EnemyCtrl enemy = collision.gameObject.GetComponent<EnemyCtrl>();
            Destroy(collision.gameObject);//������ PlayerBullet�� ������ �� ����
            Destroy(this.gameObject);//������ PlayerBullet�� ������ �Ѿ� ����

       
        }
      
        

    }
    

}
