using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Item : MonoBehaviour
{
    public float item_movingSpeed;
    float item_LimitPos;
    float item_movePos;
    float score;

    void Start()
    {
        float pressTime = 4;
        float delay = 0;
        Destroy(this.gameObject, 5.0f);//5�� �� ������ ����
    }

    void Update()
    {
        //Star_item�� ������
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
            GameObject gmobj = GameObject.Find("gmManager");

            if(gmobj != null)
            {
                GameManager gm = gmobj.GetComponent<GameManager>();
                gm.digit_score += 50; //���ھ� ���� �̹����� �ٲ���
            }

           

            
            Destroy(this.gameObject);
            //player���� Star_item�� ���̸� player�� ���ھ 50 ���� �ǰ�
            //���� player���� Star_item�� ���̸� Star_item ������Ʈ�� �����ȴ�

            
            

        }
    }
}
