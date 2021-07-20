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
        //WorldTOScrr\eenPoint: 3���� ����Ƽ �������� ��ǥ�� ����� (2D) ��ǥ�� ��ȯ
        var screenPos = Camera.main.WorldToScreenPoint(targetTr.position + offset);

        //ī�޶��� ���� ������ ��ġ�� �� ��ǥ�� ����
        if (screenPos.z < 0f)
        {
            screenPos *= -1f;
        }
        var localPos = Vector2.zero;
        //ScreenPointToLocalPointInRectangle: ��ũ��(2D)��ǥ�� RextTransform ���� ��ǥ�� ��ȯ
        //�Ķ����(�θ��� RectTreansform, ��ũ�� ��ǥ, UI ������ ī�޶�, out ��ȯ �Ϸ�� ��ǥ)
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectParent, screenPos, uiCamera, out localPos);
        //ü�¹��� ��ġ�� ������ ��ȯ�� RextTransform ��ǥ�� �����Ͽ� ��ġ ����
        rectHp.localPosition = localPos;

        

    }
}
