using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    int hp=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.left * Time.deltaTime * 4;

        if (this.transform.position.x <= -8)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if(collision.name=="Plane")
        {
            collision.gameObject.GetComponent<PlayerScr>().healing();
            //�ε��� ���==�÷��̾��� ��ũ��Ʈ�� �����ͼ� ü���� 1 ȸ�� ��Ų��
            //ü��ȸ�� �Լ��� ȣ���Ѵ�

            Destroy(this.gameObject);

        }

    }



}
