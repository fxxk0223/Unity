using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMove : MonoBehaviour
{
    public float LimitPos;//������ ���� ���� �Ǵ��ϴ� X��ǥ
    public float movePos;//������ ������ �� �̵��ϴ� X��ǥ
    public float movingSpeed;//����� �̵� �ӵ�

   

    //����� ȭ�� ������ ������ ���� ��
    //���� ȭ�鿡 ���̴� ��� �ڷ� �ٽ� �̵��ؾ� �ϱ� ������
    //�ش� ����� ������ �־�� �ڷ� �� �� �ִ�
    void Start()
    {
      
       
    }

    void Update()
    {
        //������ٵ� �̿����� �ʰ� �ڵ带 ���� ���� �߷��� �����ϴ� �� 
        this.transform.position += Vector3.left * Time.deltaTime * movingSpeed;
        if (this.transform.position.x <= LimitPos)
        {
            this.transform.position += Vector3.right * movePos;
        }
    }
}
