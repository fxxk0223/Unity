using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBullet : MonoBehaviour
{
    float speed = 10f;
    Rigidbody SpeedBulletRigidbody;
    public Vector3 moveDir = Vector3.zero;
    GameManager gm;


    void Start()
    {
        SpeedBulletRigidbody = this.GetComponent<Rigidbody>();
        SpeedBulletRigidbody.velocity = this.transform.forward *speed;


        Destroy(this.gameObject, 10f);


        GameObject target = GameObject.Find("gManager");
        if (target != null)
        {
            gm = target.GetComponent<GameManager>();
        }


    }

    void Update()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerCtrl player = other.gameObject.GetComponent<PlayerCtrl>();
            player.hp -= 1;


            if (player.hp <= 0)
            {
                player.Die();
                gm.gameOver();
            }



           

        }
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Wall")
            Destroy(this.gameObject);
    }
}
