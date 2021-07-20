using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Transform target; //카메라 추적 대상
    public float moveDamping = 5f;//이동속도 계수
    public float roatateDamping = 5f;//회전속도 계수
    public float distance = 5f;//추적 대상과의 거리
    public float height = 4f;//추적 대상과의 높이
    public float targetOffset = 2f;//추적 좌표의 오프셋 //모델의 키가 2라고 치면 아래가 아니라 정수리쪽을 보기 위해

    Transform tr;
    //스크립트에 들어가 있는 오브젝트의 tr




    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    //콜백함수-호출을 따로 하지 않아도 알아서 작동하는 변수
    //이벤트 트리거 등 여러가지 사용법이 있음
    void LateUpdate()
    {
        var camPos = target.position
             - (target.forward * distance)
             + (target.up * height);
        tr.position = Vector3.Slerp(tr.position, camPos, Time.deltaTime * moveDamping);
        tr.rotation = Quaternion.Slerp(tr.rotation, target.rotation, Time.deltaTime * roatateDamping);//유니티에서 사용하는 각도
                                                                                                      //기존의 발바닥을 쳐다보던 카메라를 오프셋만큼 윗쪽(정수리)를 보도록 수정
        tr.LookAt(target.position + (target.up * targetOffset));

    }




}

