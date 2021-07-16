using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public GameObject PlayerBullet;//�÷��̾ �߻��� �Ѿ�
    Rigidbody2D rb;
    float g_Velocity;
    public int hp = 3;//�÷��̾��� hp
    float pressTime = 1;//�߻�Ű ������ �ִ� �ð�
    float delay = 1;//�Ѿ��� �������� �߻�Ǵ� �ð�
    SpriteRenderer sr;

    public bool invincivel = false;

    public bool small_ = false;

    void Start()
    {
        hp = 3;
        pressTime = delay;
        //�Ѿ��� �Է°� ���ÿ� �߻�ǵ��� �ʱⰪ�� �����̿� ���� ���� �ش�
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
                //���콺 ����Ű�� ������ �Ѿ��� �߻��
                Instantiate(PlayerBullet, this.transform.position, Quaternion.identity);
                //�÷��̾� ��ġ���� �Ѿ� �߻�
            }


        }
        if (Input.GetMouseButtonUp(0))
        {
            pressTime = delay;
            //���콺���� ���� ���� ���� �����̸� �ʱ�ȭ�Ͽ� �Ѿ� �߻縦 �غ��Ѵ�
            //���콺�� ��� Ŭ���ϸ� �Ѿ��� ���������� �߻�ȴ�
        }
            

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //�÷��̾� ����
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


    public IEnumerator Buff()//Strong_item�� ������ 5�ʰ� ���� ���°� �ȴ�
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
                //���� ������ �� Player�� ���������� ���ϸ� �����Ÿ���
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
