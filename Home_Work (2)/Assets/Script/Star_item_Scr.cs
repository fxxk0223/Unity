using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_item_Scr : MonoBehaviour
{
    float score;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            Player player = other.gameObject.GetComponent<Player>();
            GameObject gmobj = GameObject.Find("GameManager");

            if (gmobj != null)
            {
                GameManager gm = gmobj.GetComponent<GameManager>();
                gm.score += 50; 
            }

            Destroy(this.gameObject);
        }

      
        //player에게 Star_item이 닿이면 player의 스코어가 50 증가 되고
        //또한 player에게 Star_item이 닿이면 Star_item 오브젝트가 삭제된다

    }
}
