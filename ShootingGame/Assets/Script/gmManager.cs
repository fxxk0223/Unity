using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gmManager : MonoBehaviour
{

    public float score;
    //점수 저장 변수

    int digit_score = 0;
    //실수를 정수로 점수 저장 변수

    public Text TimeText;//갱신되는 점수판

    public Text hptext;

    float scoreTime;

    public GameObject Player;

    bool isOver;


    void Start()
    {
        scoreTime = 0;
        isOver = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isOver == false)
        {
            scoreTime += Time.deltaTime;
            //점수 증가
            TimeText.text = "Score:" + (int)scoreTime;
        }

        









        //플레이어 체력 출력
        PlayerCtrl pc = Player.GetComponent<PlayerCtrl>();
        hptext.text = "HP:" + pc.hp;




    }
}
