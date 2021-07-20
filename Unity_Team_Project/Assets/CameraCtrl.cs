using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Transform target; //ī�޶� ���� ���
    public float moveDamping = 5f;//�̵��ӵ� ���
    public float roatateDamping = 5f;//ȸ���ӵ� ���
    public float distance = 5f;//���� ������ �Ÿ�
    public float height = 4f;//���� ������ ����
    public float targetOffset = 2f;//���� ��ǥ�� ������ //���� Ű�� 2��� ġ�� �Ʒ��� �ƴ϶� ���������� ���� ����

    Transform tr;
    //��ũ��Ʈ�� �� �ִ� ������Ʈ�� tr




    void Start()
    {
        tr = GetComponent<Transform>();
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
        tr.LookAt(target.position + (target.up * targetOffset));

    }




}

