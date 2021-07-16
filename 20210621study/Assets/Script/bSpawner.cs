using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bSpawner : MonoBehaviour
{
    public GameObject bullet;
    //������ �Ѿ��� �������� ������ ����

    public GameObject BigBullet;

    public GameObject SpeedBullet;

    public GameObject HpBullet;

    float bulletDelay = 0;
    //�Ѿ��� �߻��ϰ� ���� �ð� 

    public Transform playerTrans;
    //�Ѿ��� �߻��� ����� �÷��̾��� ��ġ��
    //Ȯ���ϱ� ���� �÷��̾ ������ ������

    float nextDelay = 1.0f;
    //�Ѿ� �߻翡 �ʿ��� �ð�

    void Start()
    {
        
    }


    void Update()
    {
        //������Ʈ �Լ��� 1�����ӿ� 1�� ����ȴ�
        //
        bulletDelay += Time.deltaTime;
        //Time.deltaTime: ���� �����ӿ��� ���� �������� ����Ǳ���� �ð��� �����´�
        //���� ���� ��

        if (bulletDelay >= nextDelay)
        {
            bulletDelay -= nextDelay;
            //���ذ��� 3�ʰ� �Ѿ��� ������ 3�ʸ� �ð����� ���ְ� �ٽ� ī��Ʈ�� �ϵ��� ������ش�

            nextDelay = Random.RandomRange(0.5f, 3.0f);
            //random.Range(�ּҰ�,�ִ밪)
            //������ ���� ���� ������ ���ڸ� �����ϴ� �Լ�
            //rand()�� �ٸ��� �Ǽ������� ���ڸ� �����Ѵ�

            Vector3 dir = playerTrans.position - this.transform.position;
            //������ �������� ���ϴ� ���͸� ���Ϸ���
            //������-����� ��ǥ 



            int r = Random.Range(0,5);
            //�Ǽ��� �������� ����� 0���� �ִ밪���� ����
            //������ �������� ����� 0~�ִ밪 -1������ ����
            GameObject tmp;

            switch (r)
            {
                case 1:
                   tmp = Instantiate(bullet, this.transform.position, this.transform.rotation);
                    break;
                case 2:
                    tmp = Instantiate(BigBullet, this.transform.position, this.transform.rotation);
                    break;
                case 3:
                    tmp = Instantiate(SpeedBullet, this.transform.position, this.transform.rotation);
                    break;
                default:
                    tmp = Instantiate(HpBullet, this.transform.position, this.transform.rotation);
                    break;

            }


          
            //�������̳� ���� ������Ʈ �����͸� �̿��ؼ�
            //������ ����� �������͸� �������ִ� �Լ�

            //������ ���ӿ�����Ʈ�� ��ȯ�ϱ� ������
            //�Ű������� ����� ��ȯ�� ���� ������Ʈ�� �����ϸ�
            //������ ���� ������Ʈ�� �����͸� �Ϻ� ������ �� �ִ�


            // instantiate �Լ��� ��� ���������� ���纻�� ������ִ� �Լ���
            //�Ű������� ���  �־��ִ��Ŀ� ���� ������Ʈ�� ����� ����� �޶�����

            //1.�Ű������� ������ ���ӿ�����Ʈ(������)�� �־��ָ�
            //0,0,0 ��ġ�� 0,0,0 ������ ��� ������Ʈ�� �����ϸ�

            //2. �Ű� ������ ������ ���� ������Ʈ�� �ٸ� ���ӿ�����Ʈ�� ������
            //�ι�°�� �־��� ���� ������Ʈ�� �ڽ����� ����� ���������

            //3. �Ű������� ������ ���ӿ�����Ʈ,��ǥ,������ �־��ָ�
            //������ ��ǥ�� ������ ������ ���ӿ�����Ʈ�� ���������




            tmp.transform.position -= Vector3.up ;

            tmp.transform.forward = dir;
            //�������� '��' ������ ������ ���� �������� ����
            
        }
        //==���� ���� �� ��
        //�Ҽ����� ���ǹ����� ����� ��� ���ذ��� ==���� ������ üũ�ϴ� ���� ��ǻ� �Ұ���
        //�Ҽ��� ���ϰ� ����ؼ� ������ �߻��ϱ� ������
        //==���ٴ� ������ ���ؼ� ������ �ִ� ���� ����


    }
}
