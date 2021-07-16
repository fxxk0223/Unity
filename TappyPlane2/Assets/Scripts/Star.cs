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
        //������ ���� ��ֹ�ó�� �����ʿ��� �������� �����̵��� ������ش�

        if (this.transform.position.x <= -8)
        {
            //�������� ȭ�� ������ ������
            Destroy(this.gameObject);
            //�������� ����
            //Destroy ���� �Ű������� this�� ������
            //�ش� ������Ʈ�� �ƴ϶� ��ũ��Ʈ�� ������ �ǰ� ������Ʈ�� ��� ���´�
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Plane")
        {
            GameObject gmobj = GameObject.Find("gm_manager");
            //���ӿ� �����ϴ� �Ŵ��� ������Ʈ�� Ž��
            if(gmobj!= null)
            {    //���ӸŴ����� ������ ��
                GameManager gm = gmobj.GetComponent<GameManager>();
                //���� �Ŵ������Լ� �Ŵ��� ��ũ��Ʈ�� �����ͼ�
                gm.score += 50;
                //�Ŵ��� ��ũ��Ʈ�� ������ ����
               
            }
            //�浹 ����� �����̰ų� �̸��� �׶� �׶� �ٸ��ٸ�
            //name���� tag�� ���� ����� Ȯ���ϴ� ���� ����

            Destroy(this.gameObject);

        }
    }
}
