using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{//�ε巯�� �������� �ֱ� ���� ����
    public Transform target; //ī�޶� ���� ���
    public float moveDamping = 15f;//�̵��ӵ� ���
    public float roatateDamping = 10f;//ȸ���ӵ� ���
    public float distance = 5f;//���� ������ �Ÿ�
    public float height = 4f;//���� ������ ����
    public float targetOffset = 2f;//���� ��ǥ�� ������ //���� Ű�� 2��� ġ�� �Ʒ��� �ƴ϶� ���������� ���� ����

    Transform tr;
    //��ũ��Ʈ�� �� �ִ� ������Ʈ�� tr



    [Header("벽 장애물 설정")]
    public float heightAboveWall = 7f;
    public float colliderRadius = 1.8f;
    public float overDamping = 5f;
    public float originHeight;


    void Start()
    {
        tr = GetComponent<Transform>();
        originHeight = height;

    }

    // Update is called once per frame
    //�ݹ��Լ�-ȣ���� ���� ���� �ʾƵ� �˾Ƽ� �۵��ϴ� ����
    //�̺�Ʈ Ʈ���� �� �������� ������ ����
    void LateUpdate()
    {
        var camPos = target.position
             - (target.forward * distance)
             + (target.up * height);
        tr.position = Vector3.Slerp(tr.position, camPos, Time.deltaTime * moveDamping);
        tr.rotation = Quaternion.Slerp(tr.rotation, target.rotation, Time.deltaTime * roatateDamping);//����Ƽ���� ����ϴ� ����
        //������ �߹ٴ��� �Ĵٺ��� ī�޶� �����¸�ŭ ����(������)�� ������ ����
            tr.LookAt(target.position+(target.up*targetOffset));

    }

    private void Update()
    {
        //구체 형태의 충돌체로 충돌 유무 검사
        if (Physics.CheckSphere(tr.position, colliderRadius))
        {
            height = Mathf.Lerp(height, heightAboveWall, Time.deltaTime * overDamping);
        }
        else
        {
            height = Mathf.Lerp(height, originHeight, Time.deltaTime * overDamping);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color. green;
        //DrawWireSphre (��ġ,����)
        //������ �̷��� ������ ����� �׸�(���信�� ǥ�õ�, ����׿�)
        Gizmos.DrawWireSphere(target.position + (target.up * targetOffset), 0.1f);
        //���� ī�޶�� ���� ���� ���̿� ���� �׸�
        //DrawLine(��� ����,��������)
        //��߰� ���� ���� ���̿� ���� �׸�
        Gizmos.DrawLine(target.position + (target.up * targetOffset), transform.position);

        //카메라를 감싸고 있는 충돌체를 표시하기 위한 기즈모
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, colliderRadius);


    }


}
