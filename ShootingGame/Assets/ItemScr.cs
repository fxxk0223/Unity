using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScr : MonoBehaviour
{
    public GameObject Item;
    string targetTag = "Player";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == targetTag)
        {
            Vector2 cotactPoint = collision.ClosestPoint(this.transform.position);

           
           

            if(collision.tag=="Player")
            {
                Destroy(this.gameObject);//아이템 삭제
            }
        }
    }

    internal void setTargetTag(string v)
    {
        throw new NotImplementedException();
    }
}
