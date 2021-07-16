using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public float moveSpeed;
    private Rigidbody rb;
    private Vector3 moveVec;
    public float moveRotate;


    public int hp = 3;


    public float turnSpeed = 4.0f; // ���콺 ȸ�� �ӵ�
    public float moveSpeed = 2.0f; // �̵� �ӵ�

    private float xRotate = 0.0f; // ���� ����� X�� ȸ������ ���� ���� ( ī�޶� �� �Ʒ� ���� )

    Animator animator;
    readonly int hashForward = Animator.StringToHash("Forward");//�޴���
    readonly int hashBackward = Animator.StringToHash("Backward");
    readonly int hashLeft = Animator.StringToHash("Left");
    readonly int hashRight = Animator.StringToHash("Right");
    readonly int hashMove = Animator.StringToHash("Move");


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {

        }

        if (collision.gameObject.tag == "Wall")
        {

        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void KeyboardMove()
    {
        // WASD Ű �Ǵ� ȭ��ǥŰ�� �̵����� ����
        Vector3 dir = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
        );
        // �̵����� * �ӵ� * �����Ӵ��� �ð��� ���ؼ� ī�޶��� Ʈ�������� �̵�
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
        
    void Update()
    {
        //0 ~ 1���� ������ Ŀ���� �۾���
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        //������ٵ�� Global ��ǥ�θ� �����̹Ƿ� ���� ��ǥ��� ��ȯ�Ͽ� �ٽ� ��������ߵ�
        //InverseTransformDirection ����(Global) ��ǥ > ���� ��ǥ
        Vector3 localVector = transform.InverseTransformDirection(rb.velocity);
        localVector.x = 0;
        localVector.y = 0;
        localVector.z = moveVertical;
        //TransformDirection ���� ��ǥ > ����(Global) ��ǥ
        rb.velocity = transform.TransformDirection(localVector * moveSpeed);

        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * moveHorizontal);

        if (moveVertical >= 0.1f)//����
        {
            animator.SetBool(hashForward, true);
            animator.SetBool(hashBackward, false);
            animator.SetBool(hashRight, false);
            animator.SetBool(hashLeft, false);
            animator.SetBool(hashMove, true);
        }
        else if (moveVertical <= -0.1f)//����
        {
            animator.SetBool(hashForward, false);
            animator.SetBool(hashBackward, true);
            animator.SetBool(hashRight, false);
            animator.SetBool(hashLeft, false);
            animator.SetBool(hashMove, true);
        }
        else if (moveHorizontal >= 0.1f)//����
        {
            animator.SetBool(hashForward, false);
            animator.SetBool(hashBackward, false);
            animator.SetBool(hashRight, true);
            animator.SetBool(hashLeft, false);
            animator.SetBool(hashMove, true);
        }
        else if (moveHorizontal <= -0.1f)//����
        {
            animator.SetBool(hashForward, false);
            animator.SetBool(hashBackward, false);
            animator.SetBool(hashRight, false);
            animator.SetBool(hashLeft, true);
            animator.SetBool(hashMove, true);
        }          
        else//���� �� idle ���·� ��ȯ
        {
            animator.SetBool(hashMove, false);
        }

    }
    public void die()
    {
        gameObject.SetActive(false);

        GameManager gm = GetComponent<GameManager>();
        // gameOverFunc();
        //�÷��̾ �׾��� �� gameOverFunc�� ����Ǿ����

    }
}






