using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    GameManager gm;


    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        Destroy(this.gameObject, 3.0f);//3초마다 총알이 삭제됨
    }

    void Update()
    {
       
        transform.Translate(Vector3.forward *10* Time.deltaTime);
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            

            Player player = other.gameObject.GetComponent<Player>();
            player.hp -= 1;

            if (player.hp <= 0)
            {
                player.die();
                gm.gameOverFunc();
            }

            
            Destroy(this.gameObject);
            
            //플레이어의 hp가 다 깎이면 플레이어 또한 삭제된다

        }




    }
}
