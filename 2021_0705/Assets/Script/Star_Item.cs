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
        Destroy(this.gameObject, 5.0f);//5초 뒤 아이템 삭제
    }

    void Update()
    {
        //Star_item의 움직임
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
                gm.digit_score += 50; //스코어 점수 이미지를 바꿔줌
            }

           

            
            Destroy(this.gameObject);
            //player에게 Star_item이 닿이면 player의 스코어가 50 증가 되고
            //또한 player에게 Star_item이 닿이면 Star_item 오브젝트가 삭제된다

            
            

        }
    }
}
