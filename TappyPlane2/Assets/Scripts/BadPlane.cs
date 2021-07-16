using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadPlane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.position += Vector3.left * Time.deltaTime * 5;
       

        if (this.transform.position.x <= -8)
        {
           
            Destroy(this.gameObject);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Plane")
        {
            GameObject gmobj = GameObject.Find("gm_manager");

            if (gmobj != null)
            {
                collision.GetComponent<PlayerScr>().call_Hit();
            }
            Destroy(this.gameObject);
        }
    }




}
