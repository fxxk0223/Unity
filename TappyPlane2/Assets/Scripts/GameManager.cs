using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine. UI;


public class GameManager : MonoBehaviour
{
    public GameObject gameOverImage;
    //���ӿ��� ���� �� ȭ�鿡 ������ �̹���

    public bool isGameOver;
    //���� ���� ������ �˷��ִ� ����

    public float score;
    //������ �����ϴ� ����

    public Text ScoreBoard;
    //������ ȭ�鿡 ǥ�õǴ� �ؽ�Ʈ �ڽ�

    int digit_score=0;//�Ǽ��� ���ڿ���� ��������
    //������ ������ �������ֱ� ���� ����

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
        //���� ���� ���� �� �����ų �Լ�

        Time.timeScale = 0;
        //timeScale�� ���� �󿡼� �帣�� �ð��� ������ �����ϴ� �Լ�
        //1���� ũ�� �ָ� ���� ���� �ð��� ���� �帣��
        //1���� �۰� �ָ� ���� ���� �ð��� ������ �帥��.
        //0�� �����
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
                //Ÿ�ӽ������� ���� ��ü�� ����Ǳ� ������
                //�ٸ� �� ���� ��ȯ�ϴ��� ��� ������  �ȴ�
                //���� ������ ����۵ȴٸ�
                //Ÿ�ӽ������� �ٽ� ������� �ٲ�����Ѵ� 
                SceneManager.LoadScene("GameScene");
                //TimeScale�� �ð��� �帧�� �����ߴ� ������
                //���� ��ü�� ���ߴ� �� �ƴϴ�
                //�ð��� ������� �ڵ��
                //(������Ʈ ������ deltatime�� �������� ���� ��ġ��)
                //���������� ���� �Ѵ�

            }

        }

        score += Time.deltaTime;
        //�÷���Ÿ�Ӹ�ŭ ������ ����

        ScoreBoard.text = "Score:" + (int)score;
        //�������� int ������ �ٲ㼭 �����ǿ� ǥ�� ��Ų��

        digit_score = (int)score;

        int n1000 = digit_score / 1000;//1000�� �ڸ� ����
        int n100 = (digit_score % 1000) / 100;
        int n10 = (digit_score % 100) / 10;//10�� �ڸ� ����
        int n1 = digit_score % 10;//1�� �ڸ� ����

        string fileName = "number" + n1000;        
        image1000.sprite = Resources.Load<Sprite>("Numbers/" + fileName);
        fileName = "number" + n100;
        image100.sprite = Resources.Load<Sprite>("Numbers/" + fileName);
        fileName = "number" + n10;
        image10.sprite = Resources.Load<Sprite>("Numbers/" + fileName);
        fileName = "number" + n1;
        image1.sprite = Resources.Load<Sprite>("Numbers/" + fileName);        
        //���ϸ��� ��Ģ���� ������ �ִٴ� ���� �̿��Ͽ� �ҷ��� ���ϸ���
        //�ҷ��� ���ϸ��� ���� �����ؼ� �ҷ����� �ִ�
        image1000.SetNativeSize();
        image100.SetNativeSize();
        image10.SetNativeSize();
        image1.SetNativeSize();
        //�̹��������� ����ũ�⿡ �°� ���ӿ�����Ʈ�� ũ�⸦
        //���� �����ִ� �Լ�(�������� ��ư�� ������ ���)
    }
}
