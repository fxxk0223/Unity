using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Rigidbody playerRigedbody;
    float speed = 8f;
    //변수명 앞에 public이 붙으면 유니티 에디터에서 해당 변수를 직접 눈으로 확인, 수정할 수 있게 됨
    //단, 보안에서는 취약해지기에 [SerializeField] 라는 명령어를 통해서
    //에디터에서는 보이지만 변수는 여전히 private로 남도록 만들어 줄 수 있다

    public int hp = 3;//플레이어의 체력수치


    void Start()
    {
        //클래스의 생성자와 동일한 역할을 하는 함수
        //해당 스크립트를 컴포넌트로써 가지고 있는
        //게임 오브젝트가 게임화면에 생성되면 자동으로 실행되는 함수
        playerRigedbody = this.GetComponent<Rigidbody>();
        //this로부터 컴포넌트를 가져온다 그 컴포넌트는 <Rigidbody>이다  가져온 Rigidbody 컴포넌트를 반환 받아 playerRigedbody  에 대입한다

        //에디터에서 변수를 대입하는 것과 스크립트에서 변수를 가져오는 것은 그 결과가 차이가 없지만
        //차이점으로는 에디터에서 가져오는 것은 해당 대상이 처음부터 존재할 때만 가져올 수 있고
        //스크립트로 가져올 때는 대상이 나중에 생성되더라도 가져올 수 있다

    }

    void Update()
    {
        //업데이트 함수는 게임이 실행되는 동안 1프레임마다 자동으로 호출되는 함수
        //게임을 플레이하면서 실시간으로 지속적으로 실행해야하는 코드들을 이곳에 작성한다
        //대표적인 조작:키보드와 마우스 조작

        bool b;
        //c++부터 추가된 변수형
        //참, 거짓을 표현하는 변수
        //참: true
        //거짓 :false


        //changePosition();
        // goToPosition();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 8;
        }
        moveVelocity();
      //moveForce();

    }
    //강체에 힘을 가해서 움직이는 방법
    void moveForce()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRigedbody.AddForce(Vector3.forward * speed * Time.deltaTime);
            //AddForce : 리지드바디에게 힘을 가해서 결과적으로 강체가 이동하도록 만들어주는 함수
            //매개변수로 힘을 가할 방향을 입력 받으며 방향은 x,y,z축 방향을 모두 포함해야하기 때문에 Vector3라는 클래스형을 사용한다
            //foward는 (0,0,1) 방향을 나타낸다
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerRigedbody.AddForce(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerRigedbody.AddForce(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerRigedbody.AddForce(Vector3.right * speed * Time.deltaTime);
        }

       
        //Input.GetKeyDown: 키보드 누르는 순간을 인식
        // Input.GetKeyUp: 눌렀던 키보드를 떼는 순간을 인식
        //Input.GetKey: 키보드를 누르고 있는 동안을 계속 인식
        //여러가지 키보드에 중복 대응 되게하려면 ||연산자를 통해 조건을 묶어주면 된다
        //상하좌우는 각각 중복해서 같이 누르지 않기 때문에 상하는 if-else-if로 좌우를 if-else-if로 묶어준다
        //대각선 이동을 위해 상하키 중 하나와 좌우 키 중 하나를 누를 수 있기 때문에 전체를 else if로 묶을 필요는 없다

        //AddForce함수는 강체에 힘을 가한 결과로써
        //오브젝트가 움직이게 하는 함수이기 때문에
        //즉각적인 움직임의 피드백이 가해지지 않는다
        //일정 수준 이상의 힘을 줘야 오브젝트가 움직이며
        //속도 역시 서서히 증가하면서 움직인다
        //또한 더이상 힘을 주지 않더라도 기존에 주었던 힘을 모두 소모하기 전까지는 계속해서 감소하면서 오브젝트가 움직이게 된다

        //60프레임 동작하는 게임에서 1프레임에 필요한 시간은 1/60초, 0.016초 정도가 걸린다
        //30프레임 동작하는 게임에서는 2프레임에 1/30, 0.032초가 소모된다
        //업데이트 함수를 사용할 때는 프레임의 차이에 의한 오차를 보정해주기 위해
        //프레임이 동작하는데 걸린 시간을 수치값에 곱해서 보정해주면 된다

        //변수값을 public이나 serialzeField를 통해서 에디터에서 편집이 가능하도록 만든 경우
        //변수값은 스크립트에서 초기화 해준 값-에디터에서 수정한 값-start에서 수정한 값
        //순서로 변수값이 덮어씌어진다
        //때문에 스크립트에서 값을 바꿨다해도 에디터에서 다시 값을 덮어 씌우기 때문에
        //변수값의 초기화를 애초에 start하거나 
        //혹은 에디터에서 수정되는 과정을 없애기 위해 publuc이나 serialzeField를 지워주면 된다

    }

    //강체에 속도를 직접 지정하는 방법
    void moveVelocity()
    {
        Vector3 myVelocity = Vector3.zero;
        //내가 누른 방향을 저장하는 변수
        //함수에 들어올 때마다 새로 만들기 때문에 속도가 누적될 염려를 하지 않아도 되고
        //속도값을 즉시 사용하는 게 아니라 이 변수에 각 방향을 모두 더한 후에
        //마지막으로 속도에 대입하기 때문에 대각선 이동에도 문제 없이 대응할 수 있다

        if (Input.GetKey(KeyCode.W))
        {
            myVelocity += Vector3.forward;
            //리지드바디에 힘을 가하면 가해진 힘에 의해서 속도가 증가한다
            //힘을 가한 결과로써 속도가 증가하기 때문에 속도값을 우리가 임의로 지정할 수 없다

            //반면에 리지드바디의 velocity는 결과값인 속도를 나타내는 변수이기에
            //이 속도값을 변경하면 중간과정 없이 즉시 이동이 가능해진다(가속,감속이 없다)
            //또한 속도를 정확하게 조정할 수 있다
            
        }
        else if (Input.GetKey(KeyCode.S))
        {
            myVelocity += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            myVelocity +=  Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myVelocity += Vector3.right;
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            myVelocity += Vector3.up;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            myVelocity += Vector3.down;
        }




        playerRigedbody.velocity = myVelocity*speed;
        //최종적으로 완성된 속도값을 리지드바디에 대입한다
    }


    //좌표를 직접 변경해서 움직이는 방법

    void changePosition()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            this.transform.position += Vector3.up;
        }


        //좌표를 직접 변경할 때는 현재 좌표에서 누른 방향으로 이동하여야하기 때문에
        //대입이 아닌 좌표의 더하기가 되어야 한다

        //좌표를 직접 변경하여 이동하는 방식의 경우
        //좌표값을 끊어서 변경하기 때문에
        //중간과정이 없어 다소 움직임이 끊겨 보일 수 있다
        //(한 번에 움직이는 거리를 짧게 만들면 어느정도 개선 가능)

        //좌표를 강제로 변경하기 때문에
        //설령 벽에 막혀있다 할 지라도 벽을 뚫고 좌표를 변경하게 된다

    }



    void positionTranslate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right);
        }
        //좌표변경과 동일하게 좌표값을 바꾸는 함수
        //다만 수식이 필요 없이 현지 자신의 위치를 기준으로 좌표 변경이 가능하다

    }
    //지정한 좌표로 이동 시키는 방법

    void goToPosition()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(8, 1, 8), 0.1f);
        //목적지 좌표로 이동시키는 함수
        //매개변수로 시작 지점, 도착 지점, 시간당 움직일 거리 를 입력 받는다
        //캐릭터를 이동시키되, 방향이 기준이 아니라 목적지 좌표로 이동하는 게 목표일 경우 사용하는 함수
    }

    //키보드 입력에 다중 대응하는 방법
    void moveAxis()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //개발자 입장에서 특정 입력이 어떤 동작인지
        //키보드 값이나 입력된 값만 봐서는 이해하기 힘들기 때문에
        //특정 입력에 대해 별도로 이름을 붙여서
        //알아서 보기 편하도록 만들어주는 것이 GetAxis 함수이다
        //에디터에서 edit-setting-input manaer를 통해 각 이름이 어떠한 입력을 받는 지 알 수 있다

        playerRigedbody.velocity = dir;
    }

    //총알에 부딪혔을 때 플레이어를 비활성화 시키는 함수
    //public void Die()
    //{
    //    gameObject.SetActive (false);
    //    //대문자 GameObject는 유니티 클래스인 게임오브젝트를 나타내며 
    //    //소문자 gameObject는 현재 이 스크립트컴포넌트를 가지고 있는 대상 player를 의미하게 된다
    //}


    private void OnTriggerEnter(Collider other)
    {
        
    }


    public void Die()
    {
        gameObject.SetActive(false);
    }




}
