using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]


public class MoveAgent : MonoBehaviour

{    //List도 배열이다
    //차이점은 가변 길이로서 내용물에 따라 길이가 변함

    public List<Transform> wayPoints;
    public int nextIdx;//다음 순찰 지점의 배열 인덱스

    NavMeshAgent agent;

    float damping = 1f;//회전속도 조절하는 계수
    Transform enemyTr;

    //프로퍼티 작성
    //프로퍼티란 함수인데 변수처럼 쓰이는 애

    readonly float parolSpeed = 1.5f;//읽기 전용 순찰 속도 변수
    readonly float traceSpeed = 4f;//추적 속도 변수

    bool _patrolling;//순찰 여부 판단 변수
    public bool patrolling
    {
        get { return _patrolling; }
        set
        {
            //set 동작시 전달 받은 값은 value에 들어감
            //value에 있는 값을 _patrolling 변수에 전달해줌
            _patrolling = value;
            if (_patrolling)
            {
                agent.speed = parolSpeed;
                damping = 1f;
                MoveWayPoint();
            }
        }

    }

    Vector3 _traceTarget;

    public Vector3 traceTarget
    {
        get { return _traceTarget; }
        set
        {
            _traceTarget = value;
            agent.speed = traceSpeed;
            damping = 7f;
            //추적 대상 함수 호출
            TraceTarget(_traceTarget);
        }
    }

    public float speed //agent 이동속도를 가져오는 프로퍼티 정의
    {
        //get만 존재하므로 따로 설정은 하지 못하고 값만 가져올 수 있음
        get { return agent.velocity.magnitude; }
    }



    // Start is called before the first frame update
    void Start()
    {
        patrolling = false;

        agent = GetComponent<NavMeshAgent>();
        //브레이크 꺼서 자동 감속하지 않도록 해줌
        //목적지에 가까워질수록 속도를 줄이는 옵션
        agent.autoBraking = false;
        agent.speed = parolSpeed;
        agent.updateRotation = false;

        enemyTr = GetComponent<Transform>();

        //하이어라키에서 "오브젝트 이름"으로 된 오브젝트를 검색
        var group = GameObject.Find("WayPointGroup");
        //오브젝트 정보가 존재할 경우에 실행됨(많이 씀)
        if (group != null)
        {
            //WayPointGroup 하위에 있는 모든 Transform 컴포넌트 가지고 와서 wayPoint 변수에 넣어줌
            group.GetComponentsInChildren<Transform>(wayPoints);
            //리스트에 들어가 있는 요소들 중에서 지정된 인덱스의 오브젝트 삭제
            wayPoints.RemoveAt(0);
            //리스트 찾아보기

            //하이어라키에 생성한 point들의 갯수들 중에서 랜덤한 위치를 하나 뽑아옴
            nextIdx = Random.Range(0, wayPoints.Count);
        }
        //웨이포인트 변경하는 함수 호출
        MoveWayPoint();

    }

    void MoveWayPoint()
    {
        if (agent.isPathStale)
            return;

        //만들어둔 point들 중에서 한 곳으로 목적지를 설정

        agent.destination = wayPoints[nextIdx].position;
        //네비게이션 기능 활성화해서 이동 시작하도록 변경
    }


    void TraceTarget(Vector3 pos)
    {
        if (agent.isPathStale)
            return;

        agent.destination = pos;//추적 대상 지정
        agent.isStopped = false;
    }

    public void Stop()
    {
        agent.isStopped = true;
        //바로 정지하기 위하여 잔여 속도 0으로 초기화
        agent.velocity = Vector3.zero;
        _patrolling = false;

    }



    // Update is called once per frame
    void Update()
    {

        if (!agent.isStopped)//적이 움직이는 중일 때 
        {
            //적이 진행해야될 방향 벡터를 통해 회전 각도 계산
            Quaternion rot = Quaternion.LookRotation(agent.desiredVelocity);
            enemyTr.rotation = Quaternion.Slerp(enemyTr.rotation, rot, Time.deltaTime * damping);
            //보간 함수를 사용해서 점진적으로 회전(천천히 돌리기)
        }


        if (!_patrolling)
            return;


        //목적지에 도착했는지 판단하기 위한 조건
        //속도가 0.2f보다 크고 남은 이동거리가 0.5f 이하일 경우
        //목적지에 거의 도착했을 때!!!!!~~!~!
        if (agent.velocity.sqrMagnitude >= 0.2f * 0.2f && agent.remainingDistance <= 0.5f)//.sqrMagnitude>=0.2f*0.2fr가 Magnitude 0.2f보다 계산속도 빠름
        {
            //nextIdx++;
            //0 1 2 3 4 5 6......wayPoints를 10이라고 가정
            //0 % 10 = 0
            //1% 10 = 1
            //10 % 10 = 0
            //유니티하면 존나 많이 씀

            //순환구조를 이루기 위하여 나머지 연산을 함
            //처음부터 마지막 순찰지 돌고나면 다시 처음으로 돌아가도록 인덱스 변경
            //nextIdx = nextIdx % wayPoints.Count;
            //윗쪽 코드는 순찰 지점을 순차적으로 순환하도록 했으므로 주석 처리함
            //인덱스 변경 후 이동 시작하기 위해 함수 호출

            nextIdx = Random.Range(0, wayPoints.Count);

            MoveWayPoint();

        }
    }
}
