using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceSpotLightScr : MonoBehaviour
{
    

    public void Start()
    {
       StartCoroutine(flashNow()); //코루틴 호출
    }

    

    public IEnumerator flashNow()
    {
       

      

        while (true) //문 쪽 라이트가 깜빡거리게 0.1초 간격으로 함 (코루틴 함수)
        {
            for ( int i=0; i<=10;i++)
            {
                if (i % 2 == 0)
                {
                    this.GetComponent<Light>().enabled = false;
                }
                else
                {
                    this.GetComponent<Light>().enabled = true;
                }
                yield return new WaitForSeconds(0.1f);
            }
            

        }

    }
}