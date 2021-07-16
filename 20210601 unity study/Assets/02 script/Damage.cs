using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    const string bulletTag = "BULLET";
    float iniHp = 100f;//�ʱ� ü��
    public float currHp;//���� ü��

    //��������Ʈ ����
    public delegate void PlayerDieHandler();
    //��������Ʈ�� Ȱ���� �̺�Ʈ ����
    public static event PlayerDieHandler OnPlayerDieEvent;


    public Image bloodScreen;

    public Image HpBar;
    readonly Color iniColor = new Vector4(0, 1f, 0, 1f);
    Color currColor;


    void Start()
    {
        currHp = iniHp;
        HpBar.color = iniColor;
        currColor = iniColor;
    }

    void DisplayHpBar()
    {
        if ((currHp / iniHp) > 0.5f)//���� ü���� 50�� ���� Ŭ��
            currColor.r = (1 - (currHp / iniHp)) * 2.0f;
        else //0%������ �����>������
            currColor.g = (currHp / iniHp) * 2f;

        HpBar.color = currColor;//ü�°����� ���� ����
        HpBar.fillAmount = (currHp / iniHp);//ü�� ������ ũ�� ����


    }


    //�浹�� �ƴ϶� ������ ��쿡 ����ϴ� �Լ�
    private void OnTriggerEnter(Collider other)
    {
        //�浹�� ��ü�� �±� ��
        if (other.tag == bulletTag)
        {
            Destroy(other.gameObject);


            StartCoroutine(ShowBloodScreen());
            //�¾��� �� �� ȿ�� ���̰� ��

            currHp -= 5;//ü�� 5 ����
            //print("���� ü��-"+currHp);

            DisplayHpBar();

            if (currHp <= 0f) 
            {
                //�÷��̾� ��� �Լ� ȣ��
                PlayerDie();
            }

        }
    }

    void PlayerDie()
    {
        OnPlayerDieEvent();
        //�̱��� ������ Ȱ���Ͽ� ������ ����Ǿ����� �ٷ� �����ϵ��� ��
        GameManager.instance.isGameOver = true;



        //print("�÷��̾� ���");
        //GameObject[] enemies = GameObject.FindGameObjectsWithTag("ENEMY");

        //for (int i=0;i < enemies.Length;i++)
        //{
        //    //�Լ� ȣ���� ������ ����
        //    //1.�Ʒ��� ���� ���� ȣ���ϴ� ���
        //    //enemies[i].GetComponent<EnemyAI>().OnPlayerDie();
        //    //2. �Ʒ��� ���� SendMassage�� ȣ���ϴ� ���
        //    enemies[i].SendMessage("OnPlayerDie", SendMessageOptions.DontRequireReceiver);
        //    //3. 3��° ��������Ʈ ȣ�� ���

        //}

    }


    IEnumerator ShowBloodScreen()
    {
        bloodScreen.color = new Color(1, 0, 0, Random.Range(0.2f, 0.3f));

        yield return new WaitForSeconds(0.1f);
        bloodScreen.color = Color.clear;//������ �����
    }
       


    void Update()
    {
        
    }
}
