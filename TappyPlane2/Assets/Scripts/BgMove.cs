using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMove : MonoBehaviour
{
    public float LimitPos;//밖으로 나간 건지 판단하는 X좌표
    public float movePos;//밖으로 나갔을 때 이동하는 X좌표
    public float movingSpeed;//배경의 이동 속도

   

    //배경이 화면 밖으로 나가게 됐을 때
    //현재 화면에 보이는 배경 뒤로 다시 이동해야 하기 때문에
    //해당 배경을 가지고 있어야 뒤로 갈 수 있다
    void Start()
    {
      
       
    }

    void Update()
    {
        //리지드바디를 이용하지 않고 코드를 통해 직접 중력을 구현하는 법 
        this.transform.position += Vector3.left * Time.deltaTime * movingSpeed;
        if (this.transform.position.x <= LimitPos)
        {
            this.transform.position += Vector3.right * movePos;
        }
    }
}
