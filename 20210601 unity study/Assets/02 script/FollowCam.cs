using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{//부드러운 움직임을 주기 위한 변수
    public Transform target; //카메라 추적 대상
    public float moveDamping = 15f;//이동속도 계수
    public float roatateDamping = 10f;//회전속도 계수
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
            tr.LookAt(target.position+(target.up*targetOffset));

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color. green;
        //DrawWireSphre (위치,지름)
        //선으로 이뤄진 구형의 모양의 그림(씬뷰에만 표시됨, 디버그용)
        Gizmos.DrawWireSphere(target.position + (target.up * targetOffset), 0.1f);
        //메인 카메라와 추적 지점 사이에 선을 그림
        //DrawLine(출발 지점,도착지점)
        //출발과 도착 지점 사이에 선을 그림
        Gizmos.DrawLine(target.position + (target.up * targetOffset), transform.position);


    }


}
