using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverImage;
    //게임 오버가 됐을 때 화면에 보여지는 이미지

    public GameObject Restarttext; 
    //게임 오버 됐을 때 화면에 띄울 재시작 텍스트
    

    public bool isGameOver;
    //게임 오버 유무를 알려주는 변수

    public float score;
    //점수 저장 변수

    //public GameObject ScoreBoard;
    //화면에 점수가 표시될 텍스트

    public int digit_score = 0;
    //실수로 저장된 변수를 정수로 저장해주는 변수

    

    public Image image1000;
    public Image image100;
    public Image image10;
    public Image image1;
    //image 1~1000자릿수를 불러옴






    void Start()
    {
        isGameOver = false;//처음엔 게임 오버가 안 됨
        score = 0;//스코어 0부터 시작
    }

    public void gameOverFun()//게임 오버가 될 때 실행되는 함수
    {
        Time.timeScale = 0;//게임 오버 되면 게임이 멈춘다
        gameOverImage.SetActive(true);
        Restarttext.SetActive(true);
        isGameOver = true;
    }

    void Update()
    {



        if (isGameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                
                SceneManager.LoadScene("SampleScene");
                //R키 누르면 재시작 (SampleScene을 실행) 


            }

        }


        //ScoreBoard.gameObject.SetActive(true);//스코어보드 대신 이미지를 첨부했으니 주석처리함



        //스코어의 숫자 이미지를 바꿔주는 함수
        int n1000 = digit_score / 1000;//1000의 자리 숫자
        int n100 = (digit_score % 1000) / 100;
        int n10 = (digit_score % 100) / 10;//10의 자리 숫자
        int n1 = digit_score % 10;//1의 자리 숫자

        string fileName = string.Format("PNG/HUD/text_{0}_small", n1000);
        image1000.sprite = Resources.Load<Sprite>(fileName);
        fileName = string.Format("PNG/HUD/text_{0}_small", n100);
        image100.sprite = Resources.Load<Sprite>(fileName);
        fileName = string.Format("PNG/HUD/text_{0}_small", n10);
        image10.sprite = Resources.Load<Sprite>(fileName);
        fileName = string.Format("PNG/HUD/text_{0}_small", n1);
        image1.sprite = Resources.Load<Sprite>(fileName);

        //파일명이 규칙성을 가지고 있다는 점을 이용하여 불러올 파일명을
        //불러올 파일명을 직접 조합해서 불러오고 있다

        //image1000.SetNativeSize();
        //image100.SetNativeSize();
        //image10.SetNativeSize();
        //image1.SetNativeSize();
        

        
        




    }
}
