using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myost_upper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //장애물을 왼쪽으로 이동 시키고 왼쪽 화면 밖으로 완전히 나가면 오른쪽 화면 밖으로 이동 시킨다(돌려쓰기)
        this.transform.position += Vector3.left * 4 * Time.deltaTime;
        if (this.transform.position.x<=-4)
        {
            Vector3 resetPos = this.transform.position;
            resetPos.x += 8;
            resetPos.y = Random.Range(1, 2.5f);
            //높이를 랜덤하게
            this.transform.position = resetPos;
            //설정된 좌표를 대입

            //transform.position의 x,y,z값을
            //각각 따로 바꿀 수 없기 때문에
            //위처럼 별도의 변수에 저장하고
            //수치를 수정한 뒤에 다시 고쳐주고 있다



            this.transform.position += Vector3.right * 8;
            //오른쪽 화면으로 이동


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Plane")
        {
            Debug.Log("Hit");
            collision.GetComponent<PlayerScr>().call_Hit();
            //코루틴 함수는 호출 뿐만이 아니라 startCoroutine을 통해 함수를 실행 시켜야 한다
        }
    }
}
