using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_item : MonoBehaviour
{
    int hp = 0;
    public float item_movingSpeed;
    float item_LimitPos;
    float item_movePos;

    float pressTime = 0;
    float delay = 1;

    void Start()
    {
       
        float pressTime = 2;
        float delay = 0;
        Destroy(this.gameObject, 5.0f);//5�� �� ������ ����
    }

    void Update()
    {
        //Heal_item�� ������
        this.transform.position += Vector3.left * Time.deltaTime * item_movingSpeed;
        if (this.transform.position.x <= item_LimitPos)
        {
            this.transform.position += Vector3.right * item_movePos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerCtrl player = collision.gameObject.GetComponent<PlayerCtrl>();
            GameObject gmobj2 = GameObject.Find("gmManager2");

            if (gmobj2 != null)
            {
                _gmManager2 gm2 = gmobj2.GetComponent<_gmManager2>();

                gm2._hp++; //hp �̹��� ���� ����
                player.hp ++;//player�� hp ����
            }

            Destroy(this.gameObject);
            //player���� Heal_item�� ���̸� player�� ü���� 1 ȸ�� �ǰ�
            //���� player���� Heal_item�� ���̸� Healitem ������Ʈ�� �����ȴ�

        }
    }
}
