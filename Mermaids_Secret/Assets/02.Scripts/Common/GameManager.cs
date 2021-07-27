using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //게임 매니저 싱글톤
    private static GameManager m_G_instance = null;
    public static GameManager instance
    {
        get
        {
            if(m_G_instance == null)
            {
                m_G_instance = new GameManager();
                //DontDestroyOnLoad(); //나중에 생길, 유지해야 할 오브젝트 삽입
            }
            return m_G_instance;
        }
    }

    //수중 배경 관련
    private int m_i_bubbleMax = 13;//최대 생성할 버블 개수    
    [SerializeField]
    private GameObject m_G_bubble; //버블 프리팹   
    [SerializeField]
    private GameObject m_G_bubbleParents; //버플 프리팹이 생성될 부모 폴더

    private void Start()
    {
        Init();
        //ItemManager.instance.Init();
    }

    //Start에서 실행될 매니저 함수 묶음
    void Init()
    {
        makin_Bubble();
    }

    //수중 물거품 랜덤 위치 생성
    void makin_Bubble()
    {
        for (int i = 0; i < m_i_bubbleMax; i++)
        {
            float ranX = Random.Range(40f, 130f);
            float ranZ = Random.Range(40f, 150f);
            m_G_bubble.transform.position = new Vector3(ranX, 0f, ranZ);
            GameObject b = Instantiate(m_G_bubble);
            b.transform.parent = m_G_bubbleParents.transform;
        } 
    }

}
