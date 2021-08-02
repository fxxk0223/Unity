using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    

    public Transform[] points;
    public GameObject enemy;

    public float createTime = 2f;//���� �ֱ�
    public int maxEnenmy = 10;//�ִ� ���� ����
    public bool isGameOver = false;

    //stactic ������ ���������� ������ �� �ֵ��� ����
    //�ٸ� ��ũ��Ʈ���� instance��� ������ �̿��ؼ� ���� ���� ����
    //�ٸ� �ߺ� �������� �ʵ��� (���� ������ �����ؾ� ��)
    //�Ʒ� �ڵ带 ���Ͽ� ���� �������
    public static GameManager instance = null;

    [Header("������Ʈ Ǯ ����")]
    public GameObject bulletPrefab;
    public int maxPool = 10;
    //List �� �Ϲ����� �迭�� �޸� ���� ���빰�� ���� ���̰� ����
    public List<GameObject> bulletPool = new List<GameObject>();

    bool isPaused;
    public CanvasGroup inventoryCG;

    [Header("데이터 저장")]

    public Text killCountTxt; //텍슻트 오류 고치기
    public int killCount;

    void LoadGameData() 
    {

        //playerPrefabs는 set / get 기능이 존재함
        // 키/값 <<< 쌍으로 데이터를 저장하고 가지고 옴
        //키는 사용자가 지정 가능, 두 번째 파라매터로 저장할 데이터
        //0이라는 것은 디폴트값
        killCount = PlayerPrefs.GetInt("KILL_COUNT",0);
        killCountTxt.text = "KILL" + killCount.ToString("0000");
    }

    public void OnInventoryOpen(bool isOpened)
    {
        //isOpened 값이 참일 경우 1 아니면 0 값이 설정됨
        inventoryCG.alpha = (isOpened) ? 1f : 0f;
        //interactable 은 상호 작용
        //blocksRaycasts = 없는 것
        inventoryCG.interactable = isOpened;
        inventoryCG.blocksRaycasts = isOpened;
        
    }

    public void OnPauseClick()
    {
        //bool ���� ������ �� �Ʒ��� ���� ����� �����ϴ�
        isPaused = !isPaused;
        //���� ������ >> ���ǽ� ? �� : ����
        //Timescale�� 1�� ���� 1���� ������ �������ٰ� 0�̵Ǹ� �Ͻ�����
        //1���� Ŀ���� ��� ��������� 4��� �̻� ���� ����
        Time.timeScale = (isPaused) ? 0f : 1f;

        var PlayerObj = GameObject.FindGameObjectWithTag("PLAYER");
        var scripts = PlayerObj.GetComponents<MonoBehaviour>();
        foreach (var script in scripts)
        {
            script.enabled = !isPaused;
        }
        var canvasGroup = GameObject.Find("Panel_Weapon").GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = !isPaused;
    }



    private void Awake()
    {
        //�̱����� �������� ���� ���
        if (instance == null)
        {
            instance = this;//�̱��� �������� �������

        }
        //instance�� �Ҵ�� Ŭ������ �ν��Ͻ��� �ٸ� ���
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
        //���� ����Ǵ��� �������� �ʴ��� ������
        DontDestroyOnLoad(this.gameObject);

        LoadGameData(); //게임 시작할 때 저장된 스코어 불러오기

        CreatePooling();//������Ʈ Ǯ ����

    }

    public void incKillCount()
    {
        killCount++;
        killCountTxt.text = "KILL" + killCount.ToString("0000");
        PlayerPrefs.SetInt("KILL_COUNT",killCount);
    }

    void Start()
    {
        points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();

        if (points.Length > 0)
        {
            //���� �ڷ�ƾ �Լ� ȣ��
            StartCoroutine (CreateEnemy());

        }

    }

     IEnumerator CreateEnemy()
    {
        //���� ���� ������ ��� �����
        while (!isGameOver)
        {
            //�±׸� Ȱ���Ͽ� Enemy�� ���� �ľ�
            int enemyCount = (int)GameObject.FindGameObjectsWithTag("ENEMY").Length;
            //Enemy�� �ִ� ���� �������� ���� ���� ������
            if (enemyCount < maxEnenmy)
            {
                yield return new WaitForSeconds(createTime);

                int idx = Random.Range(1, points.Length);
                Instantiate(enemy, points[idx].position, points[idx].rotation);
            }

            else
            {
                yield return null;
            }
        }
    }

    //������Ʈ Ǯ �߿��� ��� ������ �Ѿ� ��������
    public GameObject GetBullet()
    {
        for(int i = 0; i < bulletPool.Count; i++)
        {
            //�Ѿ��� ��Ȱ��ȭ �Ǿ��ִٸ� = ������̶��
            if (bulletPool[i].activeSelf == false)
            {
                return bulletPool[i];
            }
            
        }
        return null;
    }

    public void CreatePooling()
    {
        GameObject objectPools = new GameObject("ObjectPools");
        //���̾��Ű���� Create Enpty�ϴ� �Ͱ� ����
        //�� ������Ʈ�� ������ �� �̸��� ObjerxtPools�� ����
        //������ �Ѿ�(10��)�� �ڽ����� �����ϱ� ���Ͽ� �ڵ�� ����
        


        //������Ʈ Ǯ ä���

        for(int i = 0; i < maxPool; i++)
        {
            //���� ������ ���ÿ� ������ ������ ObjectPools�� �ڽ����� ����
            var obj = Instantiate<GameObject>(bulletPrefab, objectPools.transform);

            //Bullet_00, Bullet_01........Bullet_09...........10
            //�ڸ��� ���߷��� ���� �͡�
            obj.name = "Bullet_" + i.ToString("00");
            obj.SetActive(false);//�߻� ���̹Ƿ� ��Ȱ��ȭ
            bulletPool.Add(obj);//����Ʈ�� ������ �Ѿ� �߰�


        }
    }


    void Update()
    {
        
    }
}
