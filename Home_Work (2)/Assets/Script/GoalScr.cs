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
        //골 오브젝트에 닿이면 골 텍스트가 나오며 게임이 정지 된다

        if (other.gameObject.tag == "Player")
        {

            Player player = other.gameObject.GetComponent<Player>();

            gm.GoalFunc();

            Destroy(this.gameObject);
        }

    }

}





