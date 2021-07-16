using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletctrl : MonoBehaviour
{
    public float damage = 20f;//총알 공격력
    public float speed = 1000f;//총알 날아가는 속도
    //Rigidbody rb;

    Transform tr;
    Rigidbody rb;
    TrailRenderer trail;
    
    void Awake()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();

        //rb.AddForce(transform.forward * speed);



        //GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }

    private void OnEnable()
    {
        rb.AddForce(transform.forward * speed);
    }


    private void OnDisable()
    {
        trail.Clear();// 항상 클리어
        tr.position = Vector3.zero;
        tr.rotation = Quaternion.identity;
        rb.Sleep();
    }
}
