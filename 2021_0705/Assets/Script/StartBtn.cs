using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void pressStartButton()
    {
        SceneManager.LoadScene("SampleScene");
        //로드씬 함수는 씬의 이름을 지정해서 불러올 수도 있고 빌드세팅의 씬의 번호를 지정해서 불러올 수도 있다
        //버튼을 누르면 SampleScene 불러옴 
    }
}
