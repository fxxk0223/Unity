using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gmManager : MonoBehaviour
{

    public float score;
    //���� ���� ����

    int digit_score = 0;
    //�Ǽ��� ������ ���� ���� ����

    public Text TimeText;//���ŵǴ� ������

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
            //���� ����
            TimeText.text = "Score:" + (int)scoreTime;
        }

        









        //�÷��̾� ü�� ���
        PlayerCtrl pc = Player.GetComponent<PlayerCtrl>();
        hptext.text = "HP:" + pc.hp;




    }
}
