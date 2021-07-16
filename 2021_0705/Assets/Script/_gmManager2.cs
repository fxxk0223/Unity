using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _gmManager2 : MonoBehaviour
{
    public int _hp = 3;
    //hp 이미지 저장 변수


    
    public Image image100;
    public Image image10;
    public Image image1;

    void Start()
    {
        _hp = 3;//처음엔 3부터 시작
    }

    void Update()//hp의 이미지를 바꿔주는 함수
    {
        int hp100 = (_hp / 1000) / 100;//100의 자리 숫자
        int hp10 = (_hp % 100) / 10;//10의 자리 숫자
        int hp1 = _hp % 10;//1의 자리 숫자

        string hpfileName = string.Format("PNG/HUD/text_{0}_small", hp100);
        image100.sprite = Resources.Load<Sprite>(hpfileName);
        hpfileName = string.Format("PNG/HUD/text_{0}_small", hp10);
        image10.sprite = Resources.Load<Sprite>(hpfileName);
        hpfileName = string.Format("PNG/HUD/text_{0}_small", hp1);
        image1.sprite = Resources.Load<Sprite>(hpfileName);

        //1~100자리 숫자 이미지를 바꿔줌
    }
}
