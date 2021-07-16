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
        Destroy(this.gameObject, 15.0f);//15초 뒤 아이템 삭제
    }

    void Update()
    {
        //Small_item의 움직임
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
            //player에게 Small_item이 닿이면 player가 작아지고
            //또한 player에게 Small_item이 닿이면 Small_item이 삭제된다


        }
    }

}



