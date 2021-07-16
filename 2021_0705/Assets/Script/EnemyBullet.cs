using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    
    void Start()
    {
        Destroy(this.gameObject, 5.0f);//5초 뒤 총알 삭제
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

                    player.hp -= 1; //player의 hp 감소
                    gm2._hp -= 1; //hp 이미지 숫자 감소
                }




                //enemy의 총알이 플레이어에게 맞으면 플레이어의 hp가 줄어든다 o

                if (player.hp <= 0)//player의 체력이 0이 되면 player의 오브젝트가 삭제된다
                {
                    player.Die();
                }
            }
            Destroy(this.gameObject);//player에게 총알이 맞으면 총알이 삭제된다
        }


    }




}
