using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_Maker : MonoBehaviour
{
    public GameObject Heal_item;
    public GameObject Star_item;
    public GameObject Strong_item;
    public GameObject Small_item;

    public float item_delay = 2;
    public float item_timer = 0;




    void Start()
    {
       
    }

    void Update()
    {
        item_timer += Time.deltaTime;
        if (item_timer >= item_delay)
        {
            item_timer -= item_delay;

            float height = Random.Range(3f, -0.3f);
            //item이 랜덤하게 생성 될 높이 값

            Instantiate(Heal_item, new Vector3(8, height, -2), Quaternion.identity);//힐 아이템
            Instantiate(Star_item, new Vector3(8, height, -2), Quaternion.identity);//점수 증가 아이템
            Instantiate(Strong_item, new Vector3(8, height, -2), Quaternion.identity);//무적 아이템
            Instantiate(Small_item, new Vector3(8, height, -2), Quaternion.identity);//플레이어가 작아지는 아이템
        }


    }
}
