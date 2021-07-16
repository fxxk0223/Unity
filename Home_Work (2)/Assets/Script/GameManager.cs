using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float score;
    //���� ���� ����

    public Text ScoreBoard;
    //ȭ�鿡 ������ ǥ�õ� �ؽ�Ʈ

    public GameObject Restarttext;
    //���� ���� ���� �� ������ �ٽ� �����Ϸ��� �ؽ�Ʈ

    public GameObject GoalText;

    public bool Goal;
   
    public bool isGameOver;

    public int hp = 3;
    //hp ���� ����
    public GameObject player;

    public Text hptext;
    //hp �ؽ�Ʈ ��� 


    void Start()
    {
        isGameOver = false;//ó���� ���ӿ����� �� �ȴ�
        Goal=false;//ó���� ���� �� �ȴ�
        score = 0;//ó�� ������ ���� ������ 0�̴�
        hp = 3;//ó�� ������ ���� hp�� 3�̴�
        
    }


    public void gameOverFunc()//���� ������ �� �� ����Ǵ� �Լ�
    {
        Time.timeScale = 0;//���� ������ �Ǹ� ������ �����
        Restarttext.SetActive(true);//R������ ����� �ؽ�Ʈ ���
        isGameOver = true;//���ӿ��� ����

    }


    public void GoalFunc()
    {
        Time.timeScale = 0;//�����ϸ� ������ �����
        Restarttext.SetActive(true);//�ٽ� �����ϴ� �ؽ�Ʈ ȣ��
        GoalText.SetActive(true);
        Goal = true;//�� ����
    }

    void Update()
    {
        if (Goal == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                //����  �Ǹ� ������ �����ȴ�
                SceneManager.LoadScene("SampleScene");
                //RŰ ������ ����� (SampleScene�� ����) 

            }
        }

        if (isGameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                //���� ���� �Ǹ� ������ �����ȴ�
                SceneManager.LoadScene("SampleScene");
                //RŰ ������ ����� (SampleScene�� ����) 

            }
        }


        ScoreBoard.gameObject.SetActive(true);

        //�÷��̾� ü�� ���
        {
            Player pc = player.GetComponent<Player>();
            //player�� �÷��̾� ���� ������Ʈ�̱� ������
            //ü�°��� ������ �ִ� ������Ʈ�� PlayerCtrl�� Player ���� ������Ʈ�κ��� ���� �;��Ѵ�
            hptext.text = "HP:" + pc.hp;
        }


        //���ھ� ���
        {

            ScoreBoard.text = "Score:" + score;
        }

    }

}
