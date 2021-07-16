using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightScr : MonoBehaviour
{
    Light headLight;
    Transform tr;
    KeyCode[] keyCode_List;

    private void Awake()
    {
        
        headLight = GetComponent<Light>();
        //headLight. SetActive(true);

        //헤드라이트 껐다 켰다 할 수 있는 함수 호출
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {

        }
    }






}
