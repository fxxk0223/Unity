using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bSpawner : MonoBehaviour
{
    public GameObject bullet;
    //생성할 총알의 프리팹을 저장할 변수

    public GameObject BigBullet;

    public GameObject SpeedBullet;

    public GameObject HpBullet;

    float bulletDelay = 0;
    //총알을 발사하고 지난 시간 

    public Transform playerTrans;
    //총알을 발사할 대상인 플레이어의 위치를
    //확인하기 위해 플레이어를 변수로 가진다

    float nextDelay = 1.0f;
    //총알 발사에 필요한 시간

    void Start()
    {
        
    }


    void Update()
    {
        //업데이트 함수는 1프레임에 1번 실행된다
        //
        bulletDelay += Time.deltaTime;
        //Time.deltaTime: 이전 프레임에서 현재 프레임이 실행되기까지 시간을 가져온다
        //존나 많이 씀

        if (bulletDelay >= nextDelay)
        {
            bulletDelay -= nextDelay;
            //기준값이 3초가 넘었기 때문에 3초를 시간에서 빼주고 다시 카운트를 하도록 만들어준다

            nextDelay = Random.RandomRange(0.5f, 3.0f);
            //random.Range(최소값,최대값)
            //지정한 범위 내의 랜덤한 숫자를 생성하는 함수
            //rand()와 다르게 실수형으로 숫자를 생성한다

            Vector3 dir = playerTrans.position - this.transform.position;
            //목적지 방향으로 향하는 벡터를 구하려면
            //목적지-출발지 좌표 



            int r = Random.Range(0,5);
            //실수를 랜덤으로 만들면 0부터 최대값까지 생성
            //정수를 랜덤으로 만들면 0~최대값 -1까지를 생성
            GameObject tmp;

            switch (r)
            {
                case 1:
                   tmp = Instantiate(bullet, this.transform.position, this.transform.rotation);
                    break;
                case 2:
                    tmp = Instantiate(BigBullet, this.transform.position, this.transform.rotation);
                    break;
                case 3:
                    tmp = Instantiate(SpeedBullet, this.transform.position, this.transform.rotation);
                    break;
                default:
                    tmp = Instantiate(HpBullet, this.transform.position, this.transform.rotation);
                    break;

            }


          
            //프리팹이나 게임 오브젝트 데이터를 이용해서
            //동일한 복사된 오브젝터를 생성해주는 함수

            //생성된 게임오브젝트를 반환하기 때문에
            //매개변수를 만들어 반환된 게임 오브젝트를 저장하면
            //생성된 게임 오브젝트의 데이터를 일부 수정할 수 있다


            // instantiate 함수는 대상 오브젝ㅌ의 복사본을 만들어주는 함수로
            //매개변수를 어떻게  넣어주느냐에 따라 오브젝트를 만드는 방식이 달라진다

            //1.매개변수로 생성할 게임오브젝트(프리팹)만 넣어주면
            //0,0,0 위치에 0,0,0 각도로 대상 오브젝트를 생성하며

            //2. 매개 변수로 생성할 게임 오브젝트와 다른 게임오브젝트를 넣으면
            //두번째로 넣어준 게임 오브젝트의 자식으로 대상이 만들어지며

            //3. 매개변수로 생성할 게임오브젝트,좌표,각도를 넣어주면
            //지정한 좌표에 지정한 각도로 게임오브젝트가 만들어진다




            tmp.transform.position -= Vector3.up ;

            tmp.transform.forward = dir;
            //스포너의 '앞' 방향을 위에서 구한 방향으로 변경
            
        }
        //==절대 쓰지 말 것
        //소수점을 조건문에서 사용할 경우 기준값과 ==으로 조건을 체크하는 것은 사실상 불가능
        //소수점 이하가 계속해서 오차가 발생하기 때문에
        //==보다는 범위를 통해서 조건을 주는 것이 좋다


    }
}
