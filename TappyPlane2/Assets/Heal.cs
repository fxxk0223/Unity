using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    int hp=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.left * Time.deltaTime * 4;

        if (this.transform.position.x <= -8)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if(collision.name=="Plane")
        {
            collision.gameObject.GetComponent<PlayerScr>().healing();
            //부딪힌 대상==플레이어의 스크립트를 가져와서 체력을 1 회복 시킨다
            //체력회복 함수를 호출한다

            Destroy(this.gameObject);

        }

    }



}
