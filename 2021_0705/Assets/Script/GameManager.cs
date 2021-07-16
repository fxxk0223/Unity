using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverImage;
    //���� ������ ���� �� ȭ�鿡 �������� �̹���

    public GameObject Restarttext; 
    //���� ���� ���� �� ȭ�鿡 ��� ����� �ؽ�Ʈ
    

    public bool isGameOver;
    //���� ���� ������ �˷��ִ� ����

    public float score;
    //���� ���� ����

    //public GameObject ScoreBoard;
    //ȭ�鿡 ������ ǥ�õ� �ؽ�Ʈ

    public int digit_score = 0;
    //�Ǽ��� ����� ������ ������ �������ִ� ����

    

    public Image image1000;
    public Image image100;
    public Image image10;
    public Image image1;
    //image 1~1000�ڸ����� �ҷ���






    void Start()
    {
        isGameOver = false;//ó���� ���� ������ �� ��
        score = 0;//���ھ� 0���� ����
    }

    public void gameOverFun()//���� ������ �� �� ����Ǵ� �Լ�
    {
        Time.timeScale = 0;//���� ���� �Ǹ� ������ �����
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
                //RŰ ������ ����� (SampleScene�� ����) 


            }

        }


        //ScoreBoard.gameObject.SetActive(true);//���ھ�� ��� �̹����� ÷�������� �ּ�ó����



        //���ھ��� ���� �̹����� �ٲ��ִ� �Լ�
        int n1000 = digit_score / 1000;//1000�� �ڸ� ����
        int n100 = (digit_score % 1000) / 100;
        int n10 = (digit_score % 100) / 10;//10�� �ڸ� ����
        int n1 = digit_score % 10;//1�� �ڸ� ����

        string fileName = string.Format("PNG/HUD/text_{0}_small", n1000);
        image1000.sprite = Resources.Load<Sprite>(fileName);
        fileName = string.Format("PNG/HUD/text_{0}_small", n100);
        image100.sprite = Resources.Load<Sprite>(fileName);
        fileName = string.Format("PNG/HUD/text_{0}_small", n10);
        image10.sprite = Resources.Load<Sprite>(fileName);
        fileName = string.Format("PNG/HUD/text_{0}_small", n1);
        image1.sprite = Resources.Load<Sprite>(fileName);

        //���ϸ��� ��Ģ���� ������ �ִٴ� ���� �̿��Ͽ� �ҷ��� ���ϸ���
        //�ҷ��� ���ϸ��� ���� �����ؼ� �ҷ����� �ִ�

        //image1000.SetNativeSize();
        //image100.SetNativeSize();
        //image10.SetNativeSize();
        //image1.SetNativeSize();
        

        
        




    }
}
