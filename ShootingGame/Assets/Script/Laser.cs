using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject laserEff;
    //레이저가 적과 부딪혔을 때 부딪히는 효과를 나타내줄 애니메이션 오브젝트

    Vector3 dir = Vector3.up;//레이저가 날아가야할 방향 값을 저장하는 변수

    string targetTag = "enemy";//레이저가 충돌할 대상의 태그값 //초기값은 enemy

    public void setTargetTag(string str)
    {
        targetTag = str;
    }
    
    void Start()
    {
        
        Destroy(this.gameObject,5.0f);
    }

    void Update()
    {
        this.transform.position += this.transform.up*Time.deltaTime*3;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag==targetTag)
        {
            //상대방과 부딪히면

            Vector2 contactPoint = collision.ClosestPoint(this.transform.position);
            //콜라이더 간의 충돌이 일어났을 때
            //충돌한 지점의 좌표를 반환해주는 함수
            //코드 외우기

            GameObject eff = Instantiate(laserEff, transform.position, Quaternion.identity);
            Destroy(eff, 0.2f);


            if (collision.tag == "Player")
            {
                collision.GetComponent<PlayerCtrl>().damaged();
            }
            else
            {
                Destroy(collision.gameObject);//상대방을 삭제
            }
            Destroy(this.gameObject);//총알도 삭제
        }
       
    }
    

}
