using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float score;
    //점수 저장 변수

    public Text ScoreBoard;
    //화면에 점수가 표시될 텍스트

    public GameObject Restarttext;
    //게임 오버 됐을 때 게임을 다시 시작하려는 텍스트

    public GameObject GoalText;

    public bool Goal;
   
    public bool isGameOver;

    public int hp = 3;
    //hp 저장 변수
    public GameObject player;

    public Text hptext;
    //hp 텍스트 출력 


    void Start()
    {
        isGameOver = false;//처음엔 게임오버가 안 된다
        Goal=false;//처음엔 골이 안 된다
        score = 0;//처음 시작할 때는 점수가 0이다
        hp = 3;//처음 시작할 때는 hp가 3이다
        
    }


    public void gameOverFunc()//게임 오버가 될 때 실행되는 함수
    {
        Time.timeScale = 0;//게임 오버가 되면 게임이 멈춘다
        Restarttext.SetActive(true);//R누르면 재시작 텍스트 출력
        isGameOver = true;//게임오버 실행

    }


    public void GoalFunc()
    {
        Time.timeScale = 0;//골인하면 게임이 멈춘다
        Restarttext.SetActive(true);//다시 시작하는 텍스트 호출
        GoalText.SetActive(true);
        Goal = true;//골 실행
    }

    void Update()
    {
        if (Goal == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                //골이  되면 게임이 정지된다
                SceneManager.LoadScene("SampleScene");
                //R키 누르면 재시작 (SampleScene을 실행) 

            }
        }

        if (isGameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                //게임 오버 되면 게임이 정지된다
                SceneManager.LoadScene("SampleScene");
                //R키 누르면 재시작 (SampleScene을 실행) 

            }
        }


        ScoreBoard.gameObject.SetActive(true);

        //플레이어 체력 출력
        {
            Player pc = player.GetComponent<Player>();
            //player는 플레이어 게임 오브젝트이기 때문에
            //체력값을 가지고 있는 컴포넌트인 PlayerCtrl를 Player 게임 오브젝트로부터 가져 와야한다
            hptext.text = "HP:" + pc.hp;
        }


        //스코어 출력
        {

            ScoreBoard.text = "Score:" + score;
        }

    }

}
