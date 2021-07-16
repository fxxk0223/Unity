using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : MonoBehaviour
{
    float speed = 3f;
    Rigidbody BigbulletRigidbody;
    public Vector3 moveDir = Vector3.zero;
    GameManager gm;
   

    void Start()
    {
        BigbulletRigidbody = this.GetComponent<Rigidbody>();
        BigbulletRigidbody.velocity = this.transform.forward * 10;
        

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
            player.hp -= 2;
            

            if (player.hp <= 0)
            {
                player.Die();
                gm.gameOver();
            }
        }

        if(other.gameObject.tag=="Player"|| other.gameObject.tag == "Wall")
            Destroy(this.gameObject);

    }
}
