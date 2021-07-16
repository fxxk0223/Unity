using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _gmManager2 : MonoBehaviour
{
    public int _hp = 3;
    //hp �̹��� ���� ����


    
    public Image image100;
    public Image image10;
    public Image image1;

    void Start()
    {
        _hp = 3;//ó���� 3���� ����
    }

    void Update()//hp�� �̹����� �ٲ��ִ� �Լ�
    {
        int hp100 = (_hp / 1000) / 100;//100�� �ڸ� ����
        int hp10 = (_hp % 100) / 10;//10�� �ڸ� ����
        int hp1 = _hp % 10;//1�� �ڸ� ����

        string hpfileName = string.Format("PNG/HUD/text_{0}_small", hp100);
        image100.sprite = Resources.Load<Sprite>(hpfileName);
        hpfileName = string.Format("PNG/HUD/text_{0}_small", hp10);
        image10.sprite = Resources.Load<Sprite>(hpfileName);
        hpfileName = string.Format("PNG/HUD/text_{0}_small", hp1);
        image1.sprite = Resources.Load<Sprite>(hpfileName);

        //1~100�ڸ� ���� �̹����� �ٲ���
    }
}
