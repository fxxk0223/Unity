using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScr : MonoBehaviour
{
    float g_Velocity;//�߷� ���ӵ�/�ð��� �������� ����
    Rigidbody2D rb;
    public bool hittable;
     
    public int hp = 3;
    //�÷��׾��� ���� ü�� ��ġ


    public GameManager gm;
    //���ӸŴ��� ��ü�� ���� �Ͽ� ���ӿ��� ���� ȣ���ϱ� ����


    public GameObject[] hpcon;
    //�÷��̾��� ü�� �������� ������ ���� / ���� ������Ʈ�� �迭 
    //c#������ []�� �ڷ��� �ڿ� ���� ���ڵ� �� �־�� ��
    //ũ��� �迭�� �ʱ�ȭ�� �� �����ȴ� 
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
            //���콺Ű�� ���콺�� ���� ������ ���� ���� ������
            //Ű����ó�� Ű�ڵ带 ������� �ʰ� ���ڷ� ����Ѵ�
            //0:���� 1:������ 2:��� ��
            rb.AddForce(Vector2.up * 3, ForceMode2D.Impulse);
            //AddForce�� �Ű������� �߰��� ���� �� ������
            //�ش� �Ű������� ���� � ������� �������� ��Ÿ����
            //ForceMode2D.Impulse�� ���������� ���� ���� ���ϸ�(ĳ���Ͱ� ������ �� ����)
            //ForceMode2D.Force�� ���� ��ü�� ��� �۶߸��� �����̴�(ĳ���͸� �̵��� �� ����)
        }



    }

    void makeGravity() {
        g_Velocity += Time.deltaTime * 0.01f;
        //�ð��� ����Ͽ� �߷� ���ӵ��� �����Ѵ�
        this.transform.position += Vector3.down * g_Velocity;
        //�÷��̾��� ��ǥ�� �߷� ���ӵ� ũ�⸸ŭ �Ʒ��� ��������

    }

   public void call_Hit()
    {
        StartCoroutine(isHit());
        //�ڷ�ƾ �Լ��� ������
        //�Լ��� �����Ų ��ü���� ���� �Ǳ⿡
        //�ش� ��ü�� �����Ǹ� �Լ��� ������ ���߿� �����ȴ�
        //���� ����� �����Ǵ� �������
        //�������� �ʴ� ��󿡼� �Լ��� �θ����� ����� ���� ����
    }

    public IEnumerator isHit()
    {
        if (hittable == true)//�÷��̾ ���� �� �ִ� ���¸�
        {
            hp--;
            //��ֹ��� �浹�����Ƿ� ü���� 1 ���� ��Ų��

            damage();
            //ü���� ���ҵ� �ڿ� �������� ���ִ� �Լ� ����

            hittable = false;
            //�÷��̾ �浹�߱⿡ �ߺ� �浹���� �ʵ��� false�� ��������

            if (hp <= 0)
            {
                gm.gameOverFunc();
            }

            //�÷��̾ ��ֹ��� �ε����� �� ����Ǵ� �Լ�
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
                //�ڷ�ƾ �Լ� �� ����      yield return �� ��� ��
            }
            hittable = true;
            //������ ������ �ٽ� �浹 ������ ���·� bool ���� ���� �����ش�
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
            //ü�� �������� 3�� (0,1,2)�ۿ� ���⿡ ü���� 3���� �� ȸ���� �� ����
          hpcon[hp].SetActive(true);
          hp++;
        }
       
    }

    }
