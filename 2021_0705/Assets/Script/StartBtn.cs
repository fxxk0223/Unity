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
        //�ε�� �Լ��� ���� �̸��� �����ؼ� �ҷ��� ���� �ְ� ���弼���� ���� ��ȣ�� �����ؼ� �ҷ��� ���� �ִ�
        //��ư�� ������ SampleScene �ҷ��� 
    }
}
