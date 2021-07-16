using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScr : MonoBehaviour
{
    float g_Velocity;//중력 가속도/시간이 지날수록 증가
    Rigidbody2D rb;
    public bool hittable;
     
    public int hp = 3;
    //플레잉어의 현재 체력 수치


    public GameManager gm;
    //게임매니저 객체를 참조 하여 게임오버 등을 호출하기 위함


    public GameObject[] hpcon;
    //플레이어의 체력 아이콘을 저장할 변수 / 게임 오브젝트형 배열 
    //c#에서는 []가 자료형 뒤에 붙음 숫자도 안 넣어야 함
    //크기는 배열이 초기화될 때 결정된다 
    void Start()
    {
        g_Velocity = 0;
        rb = GetComponent<Rigidbody2D>();
        hittable = true;
    }

    void Update()
    {
       
       


        if (Input.GetMouseButtonDown(0))
        {
            //마우스키는 마우스에 따라서 갯수가 차이 나기 때문에
            //키보드처럼 키코드를 사용하지 않고 숫자로 사용한다
            //0:왼쪽 1:오른쪽 2:가운데 휠
            rb.AddForce(Vector2.up * 3, ForceMode2D.Impulse);
            //AddForce에 매개변수를 추가로 넣을 수 있으며
            //해당 매개변수는 힘을 어떤 방식으로 가할지를 나타낸다
            //ForceMode2D.Impulse는 순간적으로 강한 힘을 가하며(캐릭터가 점프할 때 쓰임)
            //ForceMode2D.Force는 힘을 전체에 고루 퍼뜨리는 형식이다(캐릭터를 이동할 때 쓰임)
        }



    }

    void makeGravity() {
        g_Velocity += Time.deltaTime * 0.01f;
        //시간에 비례하여 중력 가속도가 증가한다
        this.transform.position += Vector3.down * g_Velocity;
        //플레이어의 좌표가 중력 가속도 크기만큼 아래로 내려간다

    }

   public void call_Hit()
    {
        StartCoroutine(isHit());
        //코루틴 함수의 실행은
        //함수를 실행시킨 주체에게 종속 되기에
        //해당 주체가 삭제되면 함수의 실행이 도중에 정지된다
        //따라서 대상이 삭제되는 구조라면
        //삭제되지 않는 대상에서 함수를 부르도록 만드는 편이 좋다
    }

    public IEnumerator isHit()
    {
        if (hittable == true)//플레이어가 때릴 수 있는 상태면
        {
            hp--;
            //장애물과 충돌했으므로 체력을 1 감소 시킨다

            damage();
            //체력이 감소된 뒤에 아이콘을 꺼주는 함수 실행

            hittable = false;
            //플레이어가 충돌했기에 중복 충돌하지 않도록 false로 변경하자

            if (hp <= 0)
            {
                gm.gameOverFunc();
            }

            //플레이어가 장애물과 부딪혔을 때 실행되는 함수
            for (int i = 0; i < 20; i++)
            {
                if (i % 2 == 0)
                {
                    this.GetComponent<SpriteRenderer>().enabled = false;
                }
                else
                {
                    this.GetComponent<SpriteRenderer>().enabled = true;
                }
                yield return new WaitForSeconds(0.1f);
                //코루틴 함수 쓸 때는      yield return 을 써야 함
            }
            hittable = true;
            //무적이 끝나면 다시 충돌 가능한 상태로 bool 값을 변경 시켜준다
        }
        else
        {
            yield return null;
        }
    }
    void damage()
    {
        hpcon[hp].SetActive(false);

    }

   public void healing()
    {
        if (hp < 3)
        {
            //체력 아이콘은 3개 (0,1,2)밖에 없기에 체력이 3보다 더 회복될 수 없다
          hpcon[hp].SetActive(true);
          hp++;
        }
       
    }

    }
