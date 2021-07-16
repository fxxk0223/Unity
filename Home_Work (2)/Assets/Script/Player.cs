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


    public float turnSpeed = 4.0f; // 마우스 회전 속도
    public float moveSpeed = 2.0f; // 이동 속도

    private float xRotate = 0.0f; // 내부 사용할 X축 회전량은 별도 정의 ( 카메라 위 아래 방향 )

    Animator animator;
    readonly int hashForward = Animator.StringToHash("Forward");//메뉴판
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
        // WASD 키 또는 화살표키의 이동량을 측정
        Vector3 dir = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
        );
        // 이동방향 * 속도 * 프레임단위 시간을 곱해서 카메라의 트랜스폼을 이동
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
        
    void Update()
    {
        //0 ~ 1까지 서서히 커지고 작아짐
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        //리지드바디는 Global 좌표로만 움직이므로 로컬 좌표계로 변환하여 다시 전달해줘야됨
        //InverseTransformDirection 월드(Global) 좌표 > 로컬 좌표
        Vector3 localVector = transform.InverseTransformDirection(rb.velocity);
        localVector.x = 0;
        localVector.y = 0;
        localVector.z = moveVertical;
        //TransformDirection 로컬 좌표 > 월드(Global) 좌표
        rb.velocity = transform.TransformDirection(localVector * moveSpeed);

        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * moveHorizontal);

        if (moveVertical >= 0.1f)//전진
        {
            animator.SetBool(hashForward, true);
            animator.SetBool(hashBackward, false);
            animator.SetBool(hashRight, false);
            animator.SetBool(hashLeft, false);
            animator.SetBool(hashMove, true);
        }
        else if (moveVertical <= -0.1f)//후진
        {
            animator.SetBool(hashForward, false);
            animator.SetBool(hashBackward, true);
            animator.SetBool(hashRight, false);
            animator.SetBool(hashLeft, false);
            animator.SetBool(hashMove, true);
        }
        else if (moveHorizontal >= 0.1f)//우측
        {
            animator.SetBool(hashForward, false);
            animator.SetBool(hashBackward, false);
            animator.SetBool(hashRight, true);
            animator.SetBool(hashLeft, false);
            animator.SetBool(hashMove, true);
        }
        else if (moveHorizontal <= -0.1f)//좌측
        {
            animator.SetBool(hashForward, false);
            animator.SetBool(hashBackward, false);
            animator.SetBool(hashRight, false);
            animator.SetBool(hashLeft, true);
            animator.SetBool(hashMove, true);
        }          
        else//정지 시 idle 상태로 전환
        {
            animator.SetBool(hashMove, false);
        }

    }
    public void die()
    {
        gameObject.SetActive(false);

        GameManager gm = GetComponent<GameManager>();
        // gameOverFunc();
        //플레이어가 죽었을 때 gameOverFunc가 실행되어야함

    }
}






