using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public GameObject PlayerBullet;//플레이어가 발사할 총알
    Rigidbody2D rb;
    float g_Velocity;
    public int hp = 3;//플레이어의 hp
    float pressTime = 1;//발사키 누르고 있는 시간
    float delay = 1;//총알이 연속으로 발사되는 시간
    SpriteRenderer sr;

    public bool invincivel = false;

    public bool small_ = false;

    void Start()
    {
        hp = 3;
        pressTime = delay;
        //총알이 입력과 동시에 발사되도록 초기값을 딜레이와 같은 값을 준다
        rb = GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
        

    }

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            pressTime += Time.deltaTime;
            if (pressTime >= delay)
            {
                pressTime -= delay;
                //마우스 왼쪽키를 누르면 총알이 발사됨
                Instantiate(PlayerBullet, this.transform.position, Quaternion.identity);
                //플레이어 위치에서 총알 발사
            }


        }
        if (Input.GetMouseButtonUp(0))
        {
            pressTime = delay;
            //마우스에서 손을 떼는 순간 딜레이를 초기화하여 총알 발사를 준비한다
            //마우스를 계속 클릭하면 총알이 연속적으로 발사된다
        }
            

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //플레이어 점프
            rb.AddForce(Vector2.up * 3, ForceMode2D.Impulse);
        }

       

    }

    public void Startinvin()
    {
        StartCoroutine(Buff());

        //gameObject.SetActive(false);
    }

    public void StartSmall()
    {
        StartCoroutine(Small());
    }



    public IEnumerator Small()
    {
        if (small_ == false)
        {
            small_ = true;

        }


        PlayerCtrl player = this.gameObject.GetComponent<PlayerCtrl>();

        this.transform.localScale = Vector3.one * 1f;

        yield return new WaitForSeconds(3.0f);


        small_ = false;
        this.transform.localScale = Vector3.one * 2f;

    }


    public IEnumerator Buff()//Strong_item을 먹으면 5초간 무적 상태가 된다
    {
        if (invincivel == false)
        {
            invincivel = true;
           
        }

        for (int i = 0; i < 50; i++)
        {
            if (i % 2 == 0)
            {
                this.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().enabled = true;
                sr.material.color = Color.red;
                //무적 상태일 때 Player가 빨간색으로 변하며 깜빡거린다
            }
            yield return new WaitForSeconds(0.1f);
           
        }
        invincivel = false;
        sr.material.color = Color.white;

    }



    public void Die()
    {
        if (hp <= 0)
        {
            GameObject gmobj = GameObject.Find("gmManager");

            GameManager gm = gmobj.GetComponent<GameManager>();
            gm.gameOverFun();
            gameObject.SetActive(false);
        }
        
    }

}
