using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCtrl : MonoBehaviour
{
    public GameObject Laser;//플레이어가 발사할 레이저
    float delay=1;//총알이 연속으로 발사되는 주기
    float pressTime=1;//발사키를 누르고 있는 시간
    public Camera mainCam;
    public int hp = 3;//플레이어 체력

    public GameObject damageImg;//피해 입었을 때 보이는 이미지
         
    void Start()
    {
        pressTime = delay;
        //미사일의 레이저의 첫발은 입력과 동시에 발사되도록
        //초기값을 딜레이와 같은 값을 준다
    }



   

    void Update()
    {
        Vector3 moveDir = Vector3.zero;
        moveDir.x = Input.GetAxis("Horizontal");//수평방향
        moveDir.y = Input.GetAxis("Vertical");//수직방향
        this.transform.position += moveDir * Time.deltaTime*2;

        if (Input.GetKey(KeyCode.Space))
        {

            pressTime += Time.deltaTime;
            if (pressTime >= delay)
            {
                pressTime -= delay;
            //스페이스바를 누르면 총알이 발사된다
            Instantiate(Laser, this.transform.position, Quaternion.identity);
                //플레이어 위치에서 레이저를 발사

               
            }

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            pressTime = delay;
            //키보드를 떼는 순간 딜레이를 초기화해서 즉시 총알이 발사되는 상태로 바꿔준다
            //이렇게 하면 키보드를 누르는 동안에는 딜레이에 맞게 총알이 주기적으로 발사되고
            //키보드를 연타하게 되면 딜레이와 관계없이 총알이 연속해서 발사되게 된다
        }

        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos = Input.mousePosition;
            //화면상의 마우스 좌표를 가져오고
            mousePos = mainCam.ScreenToWorldPoint(mousePos);
            //화면상의 좌표를 카메라 기준으로 한 월드좌표로 전환

            RaycastHit2D hit = Physics2D.Raycast(mousePos, transform.forward, 100);
            //레이캐스트 : 특정 좌표에서 레이저(ray)를 쏴서
            //해당 레이저에 부딪힌 대상의 정보를 가져올 수 있도록 만드는 기능
            //부딪힌 대상이 hit에 반환되며, 대상이 없다면 hit는 null이 된다
            if (hit)
            {
               GameObject obj =  Instantiate(Laser,this.transform.position, Quaternion.identity);

                Vector3 v = hit.point;
                //충돌 위치는 2D 좌표이기에 3D 좌표인 Vector3 로 변경해서 사용한다
                Vector3 dir = v - this.transform.position;
                dir.z = 0;
                dir = dir.normalized;
                //방향값을 구하고 단위벡터로 만든 뒤
                obj.transform.up=dir;
                //레이저가 가진 이동방향값을 해당 값으로 변경한다
            }


        }

        // void setDir(Vector3 v)
        //{
        //    dir = v;
        //    public이 아닌 변수는 외부에소 접근할 수 없기에
        //    외부에서는 변수에 대입해줄 값만 함수를 전달하고
        //    실제로 변수값을 변경하는 것은 해당 스크립트에서하도록 만듦
        //}

    }



    public void damaged()
    {
        hp--;
        if (damageImg.activeSelf == false)
        {
            //피해 이미지가 꺼져있으면 
            damageImg.SetActive(true);
            //이미지를 켜줌
        }

        if (hp < 0)
        {
            Destroy(this.gameObject);
            return;//자기자신을 삭제했다면 코드가 종료되도록 리턴해준다
        }

        damageImg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Damage/playerShip3_damage" + (3 - hp));
    }
}
