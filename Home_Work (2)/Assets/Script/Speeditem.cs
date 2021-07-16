using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speeditem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            Player player = other.gameObject.GetComponent<Player>();
            // GameObject gmobj = GameObject.Find("GameManager");
            player.moveSpeed *= 1.3f;
            
            Destroy(this.gameObject);
        }
    }
}
