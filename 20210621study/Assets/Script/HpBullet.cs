using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBullet : MonoBehaviour
{
    float speed = 3f;
    Rigidbody bulletRigidbody;
    public Vector3 moveDir = Vector3.zero;
    GameManager gm;
    //총알은 처음부터 게임화면에 존재하지 않기에
    //게임 화면에 존재하는 대상을 public변수로 입력 받은 채로 시작할 수 없다
    //총알이 다른 씬에서 생성될 수도 있기에
    //따라서 에디터에서 대상을 넣어주는 것이 아닌
    //스크립트에서 능동적으로 해당 대상을 찾아서 가져올 수 있도록 해야한다

    void Start()
    {
        bulletRigidbody = this.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = this.transform.forward * 10;
        //Vector3.forward;
        //방향 값을 나타내주는 Vector3.forward~ 종류의 변수들은
        //게임씬은 기준으로 하는 변하지 않는 방향값이기 때문에
        //움직이는 대상이 어디있든, 어느 방향을 향하든. 누구의 자식으로 있든
        //항상 똑같은 방향으로 이동하게 된다

        //this.transform.forward;
        //Vector3에서 방향값을 가져오게 되면
        //어떠한 상황에도 변하지 않는 고정된 절대적인 방향이 되지만
        //특정한 게임오브젝트로 부터 방향을 가져오게 되면
        //해당 대상이 바라보는 방향을 기준으로 하여 앞뒤상하좌우가 결정된다
        //어떠한 경우에도 변한없는 방향이 아닌 
        //대상이 어디를 바라보느냐에 따라 그 방향이 유동적으로 변하는 상대적 방향이 된다

        Destroy(this.gameObject, 10f);
        //Destroy함수에 매개변수로 대상 오브젝트와 시간을 주게 되면
        //해당 시간이 지나면 자동으로 삭제가 된다

        GameObject target = GameObject.Find("gManager");
        if (target != null)
        {
            gm = target.GetComponent<GameManager>();
        }

        //Find함수는 지정한 이름으 ㄹ가진 대상이 존재하지 않으면
        //null을 반환하기에 대상이 존재할 때만 코드가 동작하도록 조건문을 통해 선별해준다

        //GameObject.Find("대상 이름")
        //해당 이름을 가진 게임 오브젝트를 게임씬에서 찾아서 반환해주는 함수
    }

    void Update()
    {

    }

    //대상의 collider가 다른 대상과 부딪혔을 때(Enter)
    //닿고 있는동안 계속(Stay)
    //닿았던 것이 떨어질 때(Exit)
    //자동으로 실행되는 함수
    //다른 대상과 부딪혔을 때 둘 중 하나가 is Trigger가 켜져있으면
    //다른 isTrigger든 아니든 상관없이 Trigger 함수가 호출이 된다
    //Trigger가 체크된 콜라이더는 다른 대상과 충돌은 하지만 물리적인 현상은 발생하지 않는다(튕겨 나오지 않고 통과한다)
    // private void OnCollisionEnter(Collision other)

    // Destroy(this.gameObject);
    //Destroy함수: 매개변수로 전달 받은 대상을 삭제해주는 함수

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            //Destroy함수: 매개변수로 전달 받은 대상을 삭제해주는 함수
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerCtrl player = other.gameObject.GetComponent<PlayerCtrl>();
            player.hp += 1;
            //유니티에서 기본적으로 제공되는 컴포넌트 뿐만이 아니라
            //사용자가 만든 스크립트 역시 컴포넌트로 취급이 된다
            //따라서 GetComponent 로 스크립트를 가져올 수있다
            //스크립트 상에서 선언된 변수에 접근하려면
            //해당 스크립트를 가진 게임오브젝트에게서 GetComponent 로 해당 스크립트를 가져와야 접근할 수 있다


            if (player.hp <= 0)
            {
                player.Die();
                gm.gameOver();
            }


            //스크립트 상에서 특정 대상을 삭제하는 코드가 존재한다면
            //해당 코드는 반드시 가장 마지막에 동작 시켜야 한다
            //삭제될 대상으로부터 동작하는 코드가 존재한다면
            //해당 코드의 동작이 정상적으로 이뤄지지 않을  수 있기  때문
           

        }
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Wall")
            Destroy(this.gameObject);
    }
}
