using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayeCtrl : MonoBehaviour
{
    //플레이어 스탯관련
    private float m_f_h;
    private float m_f_v;
    private float m_f_r;
    private Transform m_T_tr;
    private float m_f_speed = 4f; //마우스 회전속도
    [SerializeField]
    private float m_f_upPower = 1f; //상승시 가하는 힘
    Rigidbody m_R_rb;

    //상하좌우 이동시 마우스 회전속도
    [SerializeField]
    private float m_f_mouse_speedX = 3.0f;    
    [SerializeField]
    private float m_f_mouse_speedY = 3.0f;
    private float m_f_rotationY = 0f;


    //애니메이션
    private Animator m_A_swimAnim;
    private void Awake()
    {
        m_T_tr = this.GetComponent<Transform>();
        m_R_rb = this.GetComponent<Rigidbody>();
        m_A_swimAnim = this.GetComponent<Animator>();
    } 
    private void Update()
    {
        SetForMove();
    }

    void LateUpdate()
    {
        //마우스 시점에따라 상하,좌우 방향이동
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * m_f_mouse_speedX;
        m_f_rotationY -= Input.GetAxis("Mouse Y") * m_f_mouse_speedY;
        m_f_rotationY = Mathf.Clamp(m_f_rotationY, -20.0f, 60.0f);      
        transform.localEulerAngles = new Vector3(m_f_rotationY, rotationX, 0);
    }

    //기본이동
    void SetForMove()
    {
        m_f_h = Input.GetAxis("Horizontal");
        m_f_v = Input.GetAxis("Vertical");
        m_f_r = Input.GetAxis("Mouse X");

        Vector3 dir = (Vector3.forward * m_f_v) + (Vector3.right * m_f_h);
        dir = dir.normalized;
        m_T_tr.Translate(dir * m_f_speed * Time.deltaTime, Space.Self);

        if (m_f_v == 0 && m_f_h == 0)
            m_A_swimAnim.SetBool("move", false);
        else
            m_A_swimAnim.SetBool("move", true);
        if (Input.GetKey(KeyCode.Space))
            m_R_rb.AddForce(Vector3.up * m_f_upPower, ForceMode.Impulse);

        //일정 범위 안에서만 이동가능하게 막음
        float canMoveX = Mathf.Clamp(this.transform.position.x, 18f,125f);
        float canMoveY = Mathf.Clamp(this.transform.position.y, 1f, 10f);
        float canMoveZ = Mathf.Clamp(this.transform.position.z,8f, 130f);
        
        this.transform.position = new Vector3(canMoveX, canMoveY, canMoveZ);

    }


}
