using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmo : MonoBehaviour
{

    //Gizos 폴더 내에 있는 활용하고자 하는 리소스의 파일명
    public enum Type { NOMAL,WAYPOINT}
    const string wayPointFile = "Enemy";
    public Type type = Type.NOMAL;

    public Color _color = Color.yellow;
    public float _radius = 0.1f;

    private void OnDrawGizmos()
    {
        if (type==Type.NOMAL)//노말 상태
        {
            Gizmos.color = _color;
            //해당 위치에 _radius 크기만큼 기즈모를 그려라 
            //DrawSpere이므로 구체 모양으로 그림
            Gizmos.DrawSphere(transform.position, _radius);
        }
        else//웨이포인트 상태
        {
            Gizmos.color = _color;
            //DrawIcon(아이콘 표시 위치, 표시할 아이콘, 스케일 적용 여부)
            //스케일 적용 여부는 카메라 줌/아웃에 따라 아이콘 크기 변경 옵션
            Gizmos.DrawIcon(transform.position + Vector3.up*1f,wayPointFile,true);

            Gizmos.DrawWireSphere(transform.position, _radius);


        }

    }
}
