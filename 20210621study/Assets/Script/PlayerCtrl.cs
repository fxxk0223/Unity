using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Rigidbody playerRigedbody;
    float speed = 8f;
    //������ �տ� public�� ������ ����Ƽ �����Ϳ��� �ش� ������ ���� ������ Ȯ��, ������ �� �ְ� ��
    //��, ���ȿ����� ��������⿡ [SerializeField] ��� ��ɾ ���ؼ�
    //�����Ϳ����� �������� ������ ������ private�� ������ ����� �� �� �ִ�

    public int hp = 3;//�÷��̾��� ü�¼�ġ


    void Start()
    {
        //Ŭ������ �����ڿ� ������ ������ �ϴ� �Լ�
        //�ش� ��ũ��Ʈ�� ������Ʈ�ν� ������ �ִ�
        //���� ������Ʈ�� ����ȭ�鿡 �����Ǹ� �ڵ����� ����Ǵ� �Լ�
        playerRigedbody = this.GetComponent<Rigidbody>();
        //this�κ��� ������Ʈ�� �����´� �� ������Ʈ�� <Rigidbody>�̴�  ������ Rigidbody ������Ʈ�� ��ȯ �޾� playerRigedbody  �� �����Ѵ�

        //�����Ϳ��� ������ �����ϴ� �Ͱ� ��ũ��Ʈ���� ������ �������� ���� �� ����� ���̰� ������
        //���������δ� �����Ϳ��� �������� ���� �ش� ����� ó������ ������ ���� ������ �� �ְ�
        //��ũ��Ʈ�� ������ ���� ����� ���߿� �����Ǵ��� ������ �� �ִ�

    }

    void Update()
    {
        //������Ʈ �Լ��� ������ ����Ǵ� ���� 1�����Ӹ��� �ڵ����� ȣ��Ǵ� �Լ�
        //������ �÷����ϸ鼭 �ǽð����� ���������� �����ؾ��ϴ� �ڵ���� �̰��� �ۼ��Ѵ�
        //��ǥ���� ����:Ű����� ���콺 ����

        bool b;
        //c++���� �߰��� ������
        //��, ������ ǥ���ϴ� ����
        //��: true
        //���� :false


        //changePosition();
        // goToPosition();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 8;
        }
        moveVelocity();
      //moveForce();

    }
    //��ü�� ���� ���ؼ� �����̴� ���
    void moveForce()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRigedbody.AddForce(Vector3.forward * speed * Time.deltaTime);
            //AddForce : ������ٵ𿡰� ���� ���ؼ� ��������� ��ü�� �̵��ϵ��� ������ִ� �Լ�
            //�Ű������� ���� ���� ������ �Է� ������ ������ x,y,z�� ������ ��� �����ؾ��ϱ� ������ Vector3��� Ŭ�������� ����Ѵ�
            //foward�� (0,0,1) ������ ��Ÿ����
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerRigedbody.AddForce(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerRigedbody.AddForce(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerRigedbody.AddForce(Vector3.right * speed * Time.deltaTime);
        }

       
        //Input.GetKeyDown: Ű���� ������ ������ �ν�
        // Input.GetKeyUp: ������ Ű���带 ���� ������ �ν�
        //Input.GetKey: Ű���带 ������ �ִ� ������ ��� �ν�
        //�������� Ű���忡 �ߺ� ���� �ǰ��Ϸ��� ||�����ڸ� ���� ������ �����ָ� �ȴ�
        //�����¿�� ���� �ߺ��ؼ� ���� ������ �ʱ� ������ ���ϴ� if-else-if�� �¿츦 if-else-if�� �����ش�
        //�밢�� �̵��� ���� ����Ű �� �ϳ��� �¿� Ű �� �ϳ��� ���� �� �ֱ� ������ ��ü�� else if�� ���� �ʿ�� ����

        //AddForce�Լ��� ��ü�� ���� ���� ����ν�
        //������Ʈ�� �����̰� �ϴ� �Լ��̱� ������
        //�ﰢ���� �������� �ǵ���� �������� �ʴ´�
        //���� ���� �̻��� ���� ��� ������Ʈ�� �����̸�
        //�ӵ� ���� ������ �����ϸ鼭 �����δ�
        //���� ���̻� ���� ���� �ʴ��� ������ �־��� ���� ��� �Ҹ��ϱ� �������� ����ؼ� �����ϸ鼭 ������Ʈ�� �����̰� �ȴ�

        //60������ �����ϴ� ���ӿ��� 1�����ӿ� �ʿ��� �ð��� 1/60��, 0.016�� ������ �ɸ���
        //30������ �����ϴ� ���ӿ����� 2�����ӿ� 1/30, 0.032�ʰ� �Ҹ�ȴ�
        //������Ʈ �Լ��� ����� ���� �������� ���̿� ���� ������ �������ֱ� ����
        //�������� �����ϴµ� �ɸ� �ð��� ��ġ���� ���ؼ� �������ָ� �ȴ�

        //�������� public�̳� serialzeField�� ���ؼ� �����Ϳ��� ������ �����ϵ��� ���� ���
        //�������� ��ũ��Ʈ���� �ʱ�ȭ ���� ��-�����Ϳ��� ������ ��-start���� ������ ��
        //������ �������� ���������
        //������ ��ũ��Ʈ���� ���� �ٲ���ص� �����Ϳ��� �ٽ� ���� ���� ����� ������
        //�������� �ʱ�ȭ�� ���ʿ� start�ϰų� 
        //Ȥ�� �����Ϳ��� �����Ǵ� ������ ���ֱ� ���� publuc�̳� serialzeField�� �����ָ� �ȴ�

    }

    //��ü�� �ӵ��� ���� �����ϴ� ���
    void moveVelocity()
    {
        Vector3 myVelocity = Vector3.zero;
        //���� ���� ������ �����ϴ� ����
        //�Լ��� ���� ������ ���� ����� ������ �ӵ��� ������ ������ ���� �ʾƵ� �ǰ�
        //�ӵ����� ��� ����ϴ� �� �ƴ϶� �� ������ �� ������ ��� ���� �Ŀ�
        //���������� �ӵ��� �����ϱ� ������ �밢�� �̵����� ���� ���� ������ �� �ִ�

        if (Input.GetKey(KeyCode.W))
        {
            myVelocity += Vector3.forward;
            //������ٵ� ���� ���ϸ� ������ ���� ���ؼ� �ӵ��� �����Ѵ�
            //���� ���� ����ν� �ӵ��� �����ϱ� ������ �ӵ����� �츮�� ���Ƿ� ������ �� ����

            //�ݸ鿡 ������ٵ��� velocity�� ������� �ӵ��� ��Ÿ���� �����̱⿡
            //�� �ӵ����� �����ϸ� �߰����� ���� ��� �̵��� ����������(����,������ ����)
            //���� �ӵ��� ��Ȯ�ϰ� ������ �� �ִ�
            
        }
        else if (Input.GetKey(KeyCode.S))
        {
            myVelocity += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            myVelocity +=  Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myVelocity += Vector3.right;
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            myVelocity += Vector3.up;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            myVelocity += Vector3.down;
        }




        playerRigedbody.velocity = myVelocity*speed;
        //���������� �ϼ��� �ӵ����� ������ٵ� �����Ѵ�
    }


    //��ǥ�� ���� �����ؼ� �����̴� ���

    void changePosition()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            this.transform.position += Vector3.up;
        }


        //��ǥ�� ���� ������ ���� ���� ��ǥ���� ���� �������� �̵��Ͽ����ϱ� ������
        //������ �ƴ� ��ǥ�� ���ϱⰡ �Ǿ�� �Ѵ�

        //��ǥ�� ���� �����Ͽ� �̵��ϴ� ����� ���
        //��ǥ���� ��� �����ϱ� ������
        //�߰������� ���� �ټ� �������� ���� ���� �� �ִ�
        //(�� ���� �����̴� �Ÿ��� ª�� ����� ������� ���� ����)

        //��ǥ�� ������ �����ϱ� ������
        //���� ���� �����ִ� �� ���� ���� �հ� ��ǥ�� �����ϰ� �ȴ�

    }



    void positionTranslate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right);
        }
        //��ǥ����� �����ϰ� ��ǥ���� �ٲٴ� �Լ�
        //�ٸ� ������ �ʿ� ���� ���� �ڽ��� ��ġ�� �������� ��ǥ ������ �����ϴ�

    }
    //������ ��ǥ�� �̵� ��Ű�� ���

    void goToPosition()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(8, 1, 8), 0.1f);
        //������ ��ǥ�� �̵���Ű�� �Լ�
        //�Ű������� ���� ����, ���� ����, �ð��� ������ �Ÿ� �� �Է� �޴´�
        //ĳ���͸� �̵���Ű��, ������ ������ �ƴ϶� ������ ��ǥ�� �̵��ϴ� �� ��ǥ�� ��� ����ϴ� �Լ�
    }

    //Ű���� �Է¿� ���� �����ϴ� ���
    void moveAxis()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //������ ���忡�� Ư�� �Է��� � ��������
        //Ű���� ���̳� �Էµ� ���� ������ �����ϱ� ����� ������
        //Ư�� �Է¿� ���� ������ �̸��� �ٿ���
        //�˾Ƽ� ���� ���ϵ��� ������ִ� ���� GetAxis �Լ��̴�
        //�����Ϳ��� edit-setting-input manaer�� ���� �� �̸��� ��� �Է��� �޴� �� �� �� �ִ�

        playerRigedbody.velocity = dir;
    }

    //�Ѿ˿� �ε����� �� �÷��̾ ��Ȱ��ȭ ��Ű�� �Լ�
    //public void Die()
    //{
    //    gameObject.SetActive (false);
    //    //�빮�� GameObject�� ����Ƽ Ŭ������ ���ӿ�����Ʈ�� ��Ÿ���� 
    //    //�ҹ��� gameObject�� ���� �� ��ũ��Ʈ������Ʈ�� ������ �ִ� ��� player�� �ǹ��ϰ� �ȴ�
    //}


    private void OnTriggerEnter(Collider other)
    {
        
    }


    public void Die()
    {
        gameObject.SetActive(false);
    }




}
