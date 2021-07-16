using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    
    void Start()
    {
        Destroy(this.gameObject, 5.0f);//5�� �� �Ѿ� ����
    }

    void Update()
    {
        this.transform.position -= this.transform.right * Time.deltaTime * 3;


    }



   



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            PlayerCtrl player = other.gameObject.GetComponent<PlayerCtrl>();
            GameObject gmobj2 = GameObject.Find("gmManager2");

            if (player.invincivel == false)
            {
                if (gmobj2 != null)
                {
                    _gmManager2 gm2 = gmobj2.GetComponent<_gmManager2>();

                    player.hp -= 1; //player�� hp ����
                    gm2._hp -= 1; //hp �̹��� ���� ����
                }




                //enemy�� �Ѿ��� �÷��̾�� ������ �÷��̾��� hp�� �پ��� o

                if (player.hp <= 0)//player�� ü���� 0�� �Ǹ� player�� ������Ʈ�� �����ȴ�
                {
                    player.Die();
                }
            }
            Destroy(this.gameObject);//player���� �Ѿ��� ������ �Ѿ��� �����ȴ�
        }


    }




}
