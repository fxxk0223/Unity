using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//����Ƽ ���Ӿ� ���� Ŭ����
using UnityEngine.UI;
//����Ƽ ������ UI���� ��ũ��Ʈ�� ����� �� �ֵ��� ���ִ� Ŭ����




public class GameManager : MonoBehaviour
{
    //�������� ���ӸŴ����� ����
    //���� ���� ������ ǥ��(GameOverText�� ȭ�鿡 �������� ���� ����)
    //������ ���(�÷��̾��� ���� �ð��� ī��Ʈ)
    //UI�� ����(�����ϴ� ������ ui�� ������ �� �� �ֵ��� ������ ����)
    //���� ���� �ÿ� ������ ó������ �ٽ� ����

    public GameObject gameOverText;//���� �״� ���� ���� ���� �ؽ�Ʈ

    float scoreTime;//�÷��̾��� �������� �����ϴ� ����

    public Text TimeText;//�������� ������

    bool isOver;//���� ���� ������ ��Ÿ���� ����

    public GameObject player;
    //���Ӿ��� �����ϴ� �÷��̾ �ش� ������ �����Ѵ�

    public Text hptext;
    //�÷��̾��� ü���� ǥ������ �ؽ�Ʈ
    void Start()
    {
        scoreTime = 0;
        isOver = false;
    }

   public void gameOver()
    {
        //���ӿ��� �ؽ�Ʈ �ϸ鿡 ���;���
        //����� �� isOver�� Ʈ��� �ٲ���� ��

        gameOverText.SetActive(true);
        isOver = true;


        if (scoreTime > PlayerPrefs.GetFloat("HighScore")) 
            //����� �����͸� ���� �� ���� Get~�Լ��� ����ϸ�
            //������ �����Ͱ� Key�� (�̸�)�� �����ָ� �ȴ�
        {



            PlayerPrefs.SetFloat("HighScore", scoreTime);
            //PlayerPrefs: ����Ƽ�� ����Ǵµ���
            //�߻��� ������ �Ϻθ� �������� �������ִ� Ŭ����
            //Setfloat, Setint, Setstring�� ����
            //������ �ڷ����� �����͸� ������ �� �ִ�
            //�����͸� ������ ���� ����� �����͸� ������ �� �ֵ��� 
            //Key��(�̸�)�� �Բ� �ۼ��ؾ� �Ѵ�
            //PlayerPrefs.Setfloat("������ �̸�", ���� ������ ������)

            PlayerPrefs.Save();
            //Set�Լ��� �����͸� ��ϸ� �ϰ� ������ ������ ����� ���������� �����Ͱ� ����̽��� ������ �ȴ�
        }

    {
    }
        gameOverText.GetComponent<Text>().text = "Press R to Restart\nBest Time:" + (int)PlayerPrefs.GetFloat("HighScore");
    }


    void Update()
    {
        if (isOver == false)
        {


            //���� ������ ���� �ʾ��� ����
            scoreTime += Time.deltaTime;
            //������ ���� ��Ų��
            TimeText.text = "Score:" + (int)scoreTime;
            //�ؽ�Ʈ ������Ʈ�� ȭ�鿡 ǥ�õǴ� ���� ������
            //�ؽ�Ʈ ������Ʈ�� text������ ���� �ٲ�� ������
            // TimeText.text ���� �������ָ� �ȴ�
            // scoreTime ������ int�� �ƴ� ����:
            //scoreTimedms �÷����� �ð��� �����ϴ� ������
            //�ð����� ������ �ƴ� �Ǽ� ������ �帣�� ������
            //���� scoreTime�� int���̸�
            //update������ scoreTime�� �Ҽ��� ���Ͽ� ��� ���ϰ� �ǰ�
            //scoreTime�� int���̱⿡ �Ҽ����� ���غ��� ���� �������� �ʰ� ���ư��� �ȴ�


        }

        else
        {
            //���ӿ��� ���� �� ����

            if (Input.GetKeyDown(KeyCode.R))
            {
                //Ű���� RŰ�� ������ ������ ó������ ����� �ǵ��� �Ѵ�

                SceneManager.LoadScene("SampleScene");
                //������ ���Ӿ��� �ҷ����� �Լ�
                //������ ���� �θ��� �ش� ���� ����۵ȴ�

                //���� �ε��ϰ� �Ǹ� ȭ���� ���� ��� ��ο����ٵ�
                //�̴� �����ð� ���õ� ������ ������ �Ǿ����� �ʱ� �����̴�
                //�̸� �ذ��Ϸ��� ���� �ϴ� ���� ����� Ŭ���ϰ�
                //Lighting Setting���� New Lughting Settings�� Ŭ���Ͽ� ������ �����ϰ�
                //Auto Generate �� Ȱ��ȭ�Ͽ� ���� �ڵ����� ������ �����ϵ��� �����Ѵ�

              


            }

            else if (Input.GetKeyDown(KeyCode.X))
            {
                Application.Quit();
                //���α׷��� ���� �����ִ� �Լ�
                //����Ƽ �����Ϳ����� �����͸� ���� ��ų �� ���⿡ ���������� �������� ����
                //������ �����ؼ� ���� ���α׷����� ��������� ����Ǵ� �ڵ��̴�
            }
        }

        //�÷��̾� ü�� ���
        {
            PlayerCtrl pc = player.GetComponent<PlayerCtrl>();
            //player�� �÷��̾� ���� ������Ʈ�̱� ������
            //ü�°��� ������ �ִ� ������Ʈ�� PlayerCtrl��   Player ���� ������Ʈ�κ��� ���� �;��Ѵ�
            hptext.text = "HP:" + pc.hp;
        }
    }
}
