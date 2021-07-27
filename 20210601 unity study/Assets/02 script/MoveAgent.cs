using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]


public class MoveAgent : MonoBehaviour

{    //List�� �迭�̴�
    //�������� ���� ���̷μ� ���빰�� ���� ���̰� ����

    public List<Transform> wayPoints;
    public int nextIdx;//���� ���� ������ �迭 �ε���

    NavMeshAgent agent;

    float damping = 1f;//ȸ���ӵ� �����ϴ� ���
    Transform enemyTr;

    //������Ƽ �ۼ�
    //������Ƽ�� �Լ��ε� ����ó�� ���̴� ��

    readonly float parolSpeed = 1.5f;//�б� ���� ���� �ӵ� ����
    readonly float traceSpeed = 4f;//���� �ӵ� ����

    bool _patrolling;//���� ���� �Ǵ� ����
    public bool patrolling
    {
        get { return _patrolling; }
        set
        {
            //set ���۽� ���� ���� ���� value�� ��
            //value�� �ִ� ���� _patrolling ������ ��������
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
            //���� ��� �Լ� ȣ��
            TraceTarget(_traceTarget);
        }
    }

    public float speed //agent �̵��ӵ��� �������� ������Ƽ ����
    {
        //get�� �����ϹǷ� ���� ������ ���� ���ϰ� ���� ������ �� ����
        get { return agent.velocity.magnitude; }
    }



    // Start is called before the first frame update
    void Start()
    {
        patrolling = false;

        agent = GetComponent<NavMeshAgent>();
        //�극��ũ ���� �ڵ� �������� �ʵ��� ����
        //�������� ����������� �ӵ��� ���̴� �ɼ�
        agent.autoBraking = false;
        agent.speed = parolSpeed;
        agent.updateRotation = false;

        enemyTr = GetComponent<Transform>();

        //���̾��Ű���� "������Ʈ �̸�"���� �� ������Ʈ�� �˻�
        var group = GameObject.Find("WayPointGroup");
        //������Ʈ ������ ������ ��쿡 �����(���� ��)
        if (group != null)
        {
            //WayPointGroup ������ �ִ� ��� Transform ������Ʈ ������ �ͼ� wayPoint ������ �־���
            group.GetComponentsInChildren<Transform>(wayPoints);
            //����Ʈ�� �� �ִ� ��ҵ� �߿��� ������ �ε����� ������Ʈ ����
            wayPoints.RemoveAt(0);
            //����Ʈ ã�ƺ���

            //���̾��Ű�� ������ point���� ������ �߿��� ������ ��ġ�� �ϳ� �̾ƿ�
            nextIdx = Random.Range(0, wayPoints.Count);
        }
        //��������Ʈ �����ϴ� �Լ� ȣ��
        MoveWayPoint();

    }

    void MoveWayPoint()
    {
        if (agent.isPathStale)
            return;

        //������ point�� �߿��� �� ������ �������� ����

        agent.destination = wayPoints[nextIdx].position;
        //�׺���̼� ��� Ȱ��ȭ�ؼ� �̵� �����ϵ��� ����
    }


    void TraceTarget(Vector3 pos)
    {
        if (agent.isPathStale)
            return;

        agent.destination = pos;//���� ��� ����
        agent.isStopped = false;
    }

    public void Stop()
    {
        agent.isStopped = true;
        //�ٷ� �����ϱ� ���Ͽ� �ܿ� �ӵ� 0���� �ʱ�ȭ
        agent.velocity = Vector3.zero;
        _patrolling = false;

    }



    // Update is called once per frame
    void Update()
    {

        if (!agent.isStopped)//���� �����̴� ���� �� 
        {
            //���� �����ؾߵ� ���� ���͸� ���� ȸ�� ���� ���
            Quaternion rot = Quaternion.LookRotation(agent.desiredVelocity);
            enemyTr.rotation = Quaternion.Slerp(enemyTr.rotation, rot, Time.deltaTime * damping);
            //���� �Լ��� ����ؼ� ���������� ȸ��(õõ�� ������)
        }


        if (!_patrolling)
            return;


        //�������� �����ߴ��� �Ǵ��ϱ� ���� ����
        //�ӵ��� 0.2f���� ũ�� ���� �̵��Ÿ��� 0.5f ������ ���
        //�������� ���� �������� ��!!!!!~~!~!
        if (agent.velocity.sqrMagnitude >= 0.2f * 0.2f && agent.remainingDistance <= 0.5f)//.sqrMagnitude>=0.2f*0.2fr�� Magnitude 0.2f���� ���ӵ� ����
        {
            //nextIdx++;
            //0 1 2 3 4 5 6......wayPoints�� 10�̶�� ����
            //0 % 10 = 0
            //1% 10 = 1
            //10 % 10 = 0
            //����Ƽ�ϸ� ���� ���� ��

            //��ȯ������ �̷�� ���Ͽ� ������ ������ ��
            //ó������ ������ ������ ������� �ٽ� ó������ ���ư����� �ε��� ����
            //nextIdx = nextIdx % wayPoints.Count;
            //���� �ڵ�� ���� ������ ���������� ��ȯ�ϵ��� �����Ƿ� �ּ� ó����
            //�ε��� ���� �� �̵� �����ϱ� ���� �Լ� ȣ��

            nextIdx = Random.Range(0, wayPoints.Count);

            MoveWayPoint();

        }
    }
}
