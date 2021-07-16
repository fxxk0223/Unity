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

      
        //player���� Star_item�� ���̸� player�� ���ھ 50 ���� �ǰ�
        //���� player���� Star_item�� ���̸� Star_item ������Ʈ�� �����ȴ�

    }
}
