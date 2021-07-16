using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScr : MonoBehaviour
{
    [SerializeField]
    GameManager gm;

    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //�� ������Ʈ�� ���̸� �� �ؽ�Ʈ�� ������ ������ ���� �ȴ�

        if (other.gameObject.tag == "Player")
        {

            Player player = other.gameObject.GetComponent<Player>();

            gm.GoalFunc();

            Destroy(this.gameObject);
        }

    }

}





