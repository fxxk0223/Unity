using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar_ : MonoBehaviour
{
    Camera uiCamera;
    Canvas canvas;
    RectTransform rectParent;
    RectTransform rectHp;

    public Vector3 offset = Vector3.zero;
    public Transform targetTr;

   

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        uiCamera = canvas.worldCamera;
        rectParent = canvas.GetComponent<RectTransform>();
        rectHp = gameObject.GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        //WorldTOScrr\eenPoint: 3차원 유니티 공간상의 좌표를 모니터 (2D) 좌표로 변환
        var screenPos = Camera.main.WorldToScreenPoint(targetTr.position + offset);

        //카메라의 뒷쪽 영역에 위치할 때 좌표값 보정
        if (screenPos.z < 0f)
        {
            screenPos *= -1f;
        }
        var localPos = Vector2.zero;
        //ScreenPointToLocalPointInRectangle: 스크린(2D)좌표를 RextTransform 기준 좌표로 변환
        //파라미터(부모의 RectTreansform, 스크린 좌표, UI 렌더링 카메라, out 변환 완료된 좌표)
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectParent, screenPos, uiCamera, out localPos);
        //체력바의 위치를 위에서 변환된 RextTransform 좌표로 설정하여 위치 조정
        rectHp.localPosition = localPos;

        

    }
}
