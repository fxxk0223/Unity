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

        //������Ʈ ���� �״� �� �� �ִ� �Լ� ȣ��
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {

        }
    }






}
