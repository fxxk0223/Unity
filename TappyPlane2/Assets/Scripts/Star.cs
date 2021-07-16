using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
   
    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.position += Vector3.left * Time.deltaTime * 5;
        //아이템 역시 장애물처럼 오른쪽에서 왼쪽으로 움직이도록 만들어준다

        if (this.transform.position.x <= -8)
        {
            //아이템이 화면 밖으로 나가면
            Destroy(this.gameObject);
            //아이템을 삭제
            //Destroy 사용시 매개변수로 this를 넣으면
            //해당 오브젝트가 아니라 스크립트만 삭제가 되고 오브젝트는 계속 남는다
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Plane")
        {
            GameObject gmobj = GameObject.Find("gm_manager");
            //게임에 존재하는 매니저 오브젝트를 탐색
            if(gmobj!= null)
            {    //게임매니저가 존재할 때
                GameManager gm = gmobj.GetComponent<GameManager>();
                //게임 매니저에게서 매니저 스크립트를 가져와서
                gm.score += 50;
                //매니저 스크립트의 점수를 증가
               
            }
            //충돌 대상이 여럿이거나 이름이 그때 그때 다르다면
            //name보단 tag를 통해 대상을 확인하는 편이 좋다

            Destroy(this.gameObject);

        }
    }
}
