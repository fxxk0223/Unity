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
        //��ֹ��� �������� �̵� ��Ű�� ���� ȭ�� ������ ������ ������ ������ ȭ�� ������ �̵� ��Ų��(��������)
        this.transform.position += Vector3.left * 4 * Time.deltaTime;
        if (this.transform.position.x<=-4)
        {
            Vector3 resetPos = this.transform.position;
            resetPos.x += 8;
            resetPos.y = Random.Range(1, 2.5f);
            //���̸� �����ϰ�
            this.transform.position = resetPos;
            //������ ��ǥ�� ����

            //transform.position�� x,y,z����
            //���� ���� �ٲ� �� ���� ������
            //��ó�� ������ ������ �����ϰ�
            //��ġ�� ������ �ڿ� �ٽ� �����ְ� �ִ�



            this.transform.position += Vector3.right * 8;
            //������ ȭ������ �̵�


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Plane")
        {
            Debug.Log("Hit");
            collision.GetComponent<PlayerScr>().call_Hit();
            //�ڷ�ƾ �Լ��� ȣ�� �Ӹ��� �ƴ϶� startCoroutine�� ���� �Լ��� ���� ���Ѿ� �Ѵ�
        }
    }
}
