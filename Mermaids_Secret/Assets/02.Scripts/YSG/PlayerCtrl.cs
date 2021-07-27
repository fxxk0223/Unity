using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    //이동 조작 관련
    CharacterController C_chaCtrl;
    Vector3 V3_moveDir = Vector3.zero;

    float m_f_moveSpeed=3f;
    float m_f_gravity = 9.81f;
    float m_f_r;

    //애니메이션 관련
    Animator A_animator;

    //기타 조작 관련
    GameObject Item;
    internal static bool m_b_canMove;

    void Start()
    {
        C_chaCtrl = GetComponent<CharacterController>();
        A_animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Ani();
        ItemRaycast();
    }

    void Move()
    {
        m_f_r = Input.GetAxisRaw("Mouse X");

        if (C_chaCtrl.isGrounded)
        {
            V3_moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            V3_moveDir = transform.TransformDirection(V3_moveDir.normalized);
            V3_moveDir *= m_f_moveSpeed;
        }

        V3_moveDir.y -= m_f_gravity * Time.deltaTime;
        C_chaCtrl.Move(V3_moveDir * Time.deltaTime);
        transform.Rotate(m_f_r * transform.up);

    }

    void Ani()
    {
        if (C_chaCtrl.isGrounded)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            if ((h > 0 || v > 0 || h < 0 || v < 0) && Input.GetKey(KeyCode.LeftShift))
            {
                A_animator.SetBool("isWalk", false);
                A_animator.SetBool("isRun", true);
                m_f_moveSpeed = 6f;
            }
            else if (h > 0 || v > 0 || h < 0 || v < 0)
            {
                A_animator.SetBool("isWalk", true);
                A_animator.SetBool("isRun", false);
                m_f_moveSpeed = 3f;
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                A_animator.SetTrigger("Attack");
            }
            else
            {
                A_animator.SetBool("isWalk", false);
                A_animator.SetBool("isRun", false);
            }
        }
    }

    void ItemRaycast()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray.origin,ray.direction,out hit))
        {
            if(hit.transform.gameObject.CompareTag("Item"))
            {
                Item = hit.transform.gameObject;
                Item.GetComponent<Outline>().enabled = true;
            }
            else
            {
                if (Item != null)
                {
                    Item.GetComponent<Outline>().enabled = false;
                }
                return;
            }
        }
    }
}
