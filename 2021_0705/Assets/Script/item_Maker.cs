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
            //item�� �����ϰ� ���� �� ���� ��

            Instantiate(Heal_item, new Vector3(8, height, -2), Quaternion.identity);//�� ������
            Instantiate(Star_item, new Vector3(8, height, -2), Quaternion.identity);//���� ���� ������
            Instantiate(Strong_item, new Vector3(8, height, -2), Quaternion.identity);//���� ������
            Instantiate(Small_item, new Vector3(8, height, -2), Quaternion.identity);//�÷��̾ �۾����� ������
        }


    }
}
