using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strong_item : MonoBehaviour
{

    public float item_movingSpeed;
    float item_LimitPos;
    float item_movePos;

    float pressTime = 0;
    float delay = 1;
    void Start()
    {

        float pressTime = 0.0f;
        float delay = 10.0f;
        Destroy(this.gameObject, 3.0f);//3�� �� ������ ����
    }

    void Update()
    {
        //Strong_item�� ������
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

            player.Startinvin();
            

            Destroy(this.gameObject);
            //player���� Strong_item�� ���̸� player�� ���� ���°� �ǰ�
            //���� player���� Strong_item�� ���̸� Strong_item�� �����ȴ�

            




        }
    }

}
