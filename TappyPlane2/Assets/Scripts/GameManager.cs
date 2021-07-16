using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine. UI;


public class GameManager : MonoBehaviour
{
    public GameObject gameOverImage;
    //게임오버 됐을 때 화면에 보여줄 이미지

    public bool isGameOver;
    //게임 오버 유무를 알려주는 변수

    public float score;
    //점수를 저장하는 변수

    public Text ScoreBoard;
    //점수를 화면에 표시되는 텍스트 박스

    int digit_score=0;//실수로 저자오디는 점수값을
    //정수로 별도로 저장해주기 위한 변수

    public Image image1000;
    public Image image100;
    public Image image10;
    public Image image1;



    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;

        score = 0;
    }


    public void gameOverFunc()
    {
        //게임 오버 됐을 때 실행시킬 함수

        Time.timeScale = 0;
        //timeScale은 게임 상에서 흐르는 시간의 배율을 조절하는 함수
        //1보다 크게 주면 게임 상의 시간이 빨리 흐르며
        //1보다 작게 주면 게임 상의 시간이 느리게 흐른다.
        //0은 멈춘다
        gameOverImage.SetActive(true);
        isGameOver = true;
    }



    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                //타임스케일은 게임 전체에 적용되기 때문에
                //다르 씬 으로 전환하더라도 계속 유지가  된다
                //따라서 게임이 재시작된다면
                //타임스케일을 다시 원래대로 바꿔줘야한다 
                SceneManager.LoadScene("GameScene");
                //TimeScale은 시간의 흐름으 ㄹ멈추는 것이지
                //게임 전체를 멈추는 게 아니다
                //시간과 관계없는 코드들
                //(업데이트 문에서 deltatime이 곱해지지 않은 수치들)
                //정상적으로 동작 한다

            }

        }

        score += Time.deltaTime;
        //플레이타임만큼 점수를 가산

        ScoreBoard.text = "Score:" + (int)score;
        //점수값을 int 형으로 바꿔서 점수판에 표시 시킨다

        digit_score = (int)score;

        int n1000 = digit_score / 1000;//1000의 자리 숫자
        int n100 = (digit_score % 1000) / 100;
        int n10 = (digit_score % 100) / 10;//10의 자리 숫자
        int n1 = digit_score % 10;//1의 자리 숫자

        string fileName = "number" + n1000;        
        image1000.sprite = Resources.Load<Sprite>("Numbers/" + fileName);
        fileName = "number" + n100;
        image100.sprite = Resources.Load<Sprite>("Numbers/" + fileName);
        fileName = "number" + n10;
        image10.sprite = Resources.Load<Sprite>("Numbers/" + fileName);
        fileName = "number" + n1;
        image1.sprite = Resources.Load<Sprite>("Numbers/" + fileName);        
        //파일명이 규칙성을 가지고 있다는 점을 이용하여 불러올 파일명을
        //불러올 파일명을 직접 조합해서 불러오고 있다
        image1000.SetNativeSize();
        image100.SetNativeSize();
        image10.SetNativeSize();
        image1.SetNativeSize();
        //이미지파일의 원본크기에 맞게 게임오브젝트의 크기를
        //변경 시켜주는 함수(에디터의 버튼과 동일한 기능)
    }
}
