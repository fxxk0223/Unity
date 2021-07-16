using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject Item;
    public GameObject targetPos;
    float pressTime = 0;
    float delay = 1;
    public GameObject Laser;

    //��ĳ���Ͱ� ��ǥ�� �ؾ��ϴ� ����� ��ġ=�÷��̾�
    Vector3 dir;//���ʹ��� �̵�����
    void Start()
    {
        targetPos = GameObject.Find("Player");
        //��ǥ���� ã�Ƽ� ������ ����

        

    }

    void Update()
    {
        if(targetPos != null)
            //target �� �÷��̾ ������ ����
            //���ʹ̰� �÷��̾� �������� �����̰�
            //�÷��̾� �������� �Ѿ��� �߻��Ѵ�
            //�÷��̾ �Ѿ��� �°� �����ȴٸ� ���̻� �̵��� �߻絵 ���� �ʰ� �ȴ�.
        {
          dir = targetPos.transform.position - this.transform.position;

            //��ǥ���� ���� ������ ���ؼ� ������ ����
            //���� : ��ǥ��ġ-������ġ
            //������ ����� ������Ʈ�� �־��ָ�
            //�ǽð����� Ÿ�ٰ� �ڽ��� ��ġ�� ��������
            //���ο� ������ ����ؼ� �̵��ϱ� ������
            //����źó�� ��� ����´�

            if (Vector3.Distance(this.transform.position, targetPos.transform.position) > 1)
            {
                //Vector3.Distance : �� ���� ������ '�Ÿ�'�� �����ִ� �Լ�
                //�Ÿ����� float������ ��ȯ�ȴ�

                dir = dir.normalized;
                // this.transform.position += dir * Time.deltaTime * 0.8f;

                this.transform.forward = dir;
                //�ش� ������Ʈ�� �������  ����
                this.transform.position += this.transform.forward * Time.deltaTime;
                //�̵������� �ش� ������Ʈ�� �ٶ󺸸� ��������(forward) �̵���Ŵ

            }

            //���Ϳ��� ����� ũ�Ⱑ ��� ������ �Ǿ��־
            //�ܼ����͸� �̿��Ͽ� �̵� ��Ű�� �Ǹ�
            //ũ��(�Ÿ�)�� ���� �̵��ӵ��� ���̰� �߻��Ѵ�
            //�׷��� ����� ������ ũ�⸦ �����ϰ� ���⸸�� ������ �̵����Ѿ� �ϴµ�
            //�̶� �ʿ��� ���� ������ normalized (��������)�� ���̴�

            //�������ʹ� ������ ũ�⸦ 1�� ������ �����̴�
            //�׷��� ��� �������ʹ� ������ ũ�⸦ ������ ���� ���⸸ ���̰� ���� �ȴ�


            //�� ����Ⱑ �÷��̾� �������� ����������

            //Quaternion q = Quaternion.LookRotation(targetPos.transform.position);
            //�����ϴ� ��� �������� ���ϴ� �������� �ڵ����� ������ִ� �Լ�




            pressTime += Time.deltaTime;
            if (pressTime >= delay)
            {
                pressTime -= delay;
                //�����̽��ٸ� ������ �Ѿ��� �߻�ȴ�
                GameObject obj = Instantiate(Laser, this.transform.position, Quaternion.identity);
                //�÷��̾� ��ġ���� �������� �߻�
                obj.transform.up = this.transform.forward;
                //�������� �������==���ʹ��� �������
                //�������� up == ���ʹ��� forward�� �ǵ��� ���� ����
                obj.GetComponent<Laser>().setTargetTag("Player");
                //���ʹ̰� ������ �Ѿ��� ���ʹ̰� �ƴ� �÷��̾�� �ε����� �� �����ȴ�

                GameObject item = Instantiate(Item, transform.position, Quaternion.identity);
                obj.GetComponent<ItemScr>().setTargetTag("Player");

            }
        }
       
       

        

    }
}
