using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //아이템 매니저 싱글톤
    private static ItemManager m_I_instance = null;
    public static ItemManager instance
    {
        get
        {
            if (m_I_instance == null)
            {
                m_I_instance = new ItemManager();
                //DontDestroyOnLoad(); //나중에 생길, 유지해야 할 오브젝트 삽입
            }
            return m_I_instance;
        }
    }
    
    //아이템 관련
    [SerializeField]
    private int m_i_branch = 20; //생성할 나무가지 개수
    //[SerializeField]
    public GameObject[] m_G_branches; //나무가지 게임오브젝트 배열
    [SerializeField]
    private GameObject m_G_branchParents;//나무 프리팹이 생성될 부모 폴더

    private void Start()
    {
        Init();
    }

    //Start에서 실행될 매니저 함수 묶음
    public void Init()
    {
        makinBranch();
    }

    //나무가지 랜덤 위치 생성
    //계속 생기는 오브젝트는 아니니까 굳이 풀링을 쓸필요는 없을것 같다
    void makinBranch()
    {
        GameObject tmp = m_G_branches[0];
        for (int i = 0; i < m_i_branch; i++)
        {
            int rand = Random.Range(0, 3);
            float ranX = Random.Range(50f, 70f);
            float ranZ = Random.Range(60f, 90f);
            m_G_branches[rand].transform.position = new Vector3(ranX, 1f, ranZ);
            GameObject b = Instantiate(m_G_branches[rand]);
            b.transform.parent = m_G_branchParents.transform;
        }
    }

}
