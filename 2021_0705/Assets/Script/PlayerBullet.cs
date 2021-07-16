using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    Vector3 dir = Vector3.right;//총알이 날아갈 방향값
    string targetTag = "Enemy";//총알이 충돌할 대상
    void Start()
    {
        Destroy(this.gameObject, 5.0f);//총알이 발사 됐을 때 5초 후 총알을 삭제한다
    }

    void Update()
    {
        this.transform.position += this.transform.right * Time.deltaTime * 3;//총알이 오른쪽으로 날아가게 한다
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            EnemyCtrl enemy = collision.gameObject.GetComponent<EnemyCtrl>();
            Destroy(collision.gameObject);//적에게 PlayerBullet이 닿으면 적 삭제
            Destroy(this.gameObject);//적에게 PlayerBullet이 닿으면 총알 삭제

       
        }
      
        

    }
    

}
