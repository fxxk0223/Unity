using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Small_item : MonoBehaviour
{
    public float item_movingSpeed=3.0f;
    float item_LimitPos;
    float item_movePos;

    float pressTime = 0;
    float delay = 1;

    

    void Start()
    {
        float pressTime = 0.0f;
        float delay = 10.0f;
        Destroy(this.gameObject, 15.0f);//15�� �� ������ ����
    }

    void Update()
    {
        //Small_item�� ������
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

            collision.gameObject.GetComponent<PlayerCtrl>().StartSmall();


            Destroy(this.gameObject);
            //player���� Small_item�� ���̸� player�� �۾�����
            //���� player���� Small_item�� ���̸� Small_item�� �����ȴ�


        }
    }

}



