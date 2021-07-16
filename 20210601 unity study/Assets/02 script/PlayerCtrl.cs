using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//내부클래스
//클래스 직렬화
//클래스의 경우 변수와 달리 직렬화해줘야 인스펙터에 표시됨

[System.Serializable]
public class PlayerAnim
{
    public AnimationClip idle;
    public AnimationClip runF;
    public AnimationClip runB;
    public AnimationClip runL;
    public AnimationClip runR;
}



public class PlayerCtrl : MonoBehaviour
{ 
    //접근 지시자
    //private는 작성된 스크립트 내부에서만 적용됨 /존나 내꺼
    //public은 내부 외부 어디서나 쓸 수 있다 / 아무나 씀
    //기본 형태는 private임
    //추가로 protected 라는 접근 지시자가 있음/

   float h = 0f;
   float v = 0f;
   float r = 0f;//마우스 값 받아서 회전 시키기 위한 변수

    Transform tr;//트랜스폼 컴포넌트 접근 변수
    //Public으로 선언된 변수는 Inspector 창에 노출됨
    public float moveSpeed = 10f;
    public float rotSpeed = 150f;

    public PlayerAnim playerAnim;
    public Animation anim;



    // Start is called before the first frame update
    void Start()
    {
        //트랜스폼 컴포넌트와 tr변수 연결
        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();
        anim.clip = playerAnim.idle;
        anim.Play();

      
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxisRaw("Mouse X");
        //print("H값-" + h + "V값-" + v);

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        //벡터 정규화
        //대각선 이동이 일반적인 이동보다 크기가 커서 빨리 움직임
        //이를 해결하고자 벡터의 크기를 일정하게 1로 정규화 시킴
       
        moveDir = moveDir.normalized;
      
        tr.Translate(moveDir * moveSpeed  * Time.deltaTime, Space.Self); //스피드 동일하게 하기 위해 Time.deltaTime을 쓴다
        tr.Rotate(Vector3.up * rotSpeed * Time.deltaTime * r);
        //print(Vector3.Magnitude(Vector3.forward + Vector3.right));
        //print(Vector3.Magnitude((Vector3.forward + Vector3.right).normalized));
        //애니메이션 동작 구분 구현
        if(v>=0.1f)//전진
        {
            //CrossFade(애니메이션 이름, 전환 시간)
            anim.CrossFade(playerAnim.runF.name, 0.3f);
        }
        else if(v <= -0.1f)//후진
        {
            anim.CrossFade(playerAnim.runB.name, 0.3f);
        }
        else if(h>=0.1f)//우측
            anim.CrossFade(playerAnim.runR.name, 0.3f);
        else if (h<= -0.1f)//좌측
            anim.CrossFade(playerAnim.runL.name, 0.3f);
        else//정지 시 idle 상태로 전환
            anim.CrossFade(playerAnim.idle.name, 0.3f);
    }
}
