using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler
{
    Transform itemTr;
    Transform inventotyTr;
    Transform itemListTr;
    CanvasGroup canvasGroup;
    //드래그 중인 아이템이 무엇인지 명확히 하기 위한 변수
    //static = 공용 속성을 지니도록 만듦 ex) 약수터 같은 느낌
   public static GameObject draggingitem = null;

   
    void Start()
    {
        itemTr = GetComponent<Transform>();
        inventotyTr = GameObject.Find("Inventory").GetComponent<Transform>();
        itemListTr = GameObject.Find("itemList").GetComponent<Transform>();

        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        itemTr.position = Input.mousePosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(inventotyTr);
        //드래그 중인 아이템의 정보를 저장
        draggingitem = this.gameObject;
        //드래그가 시작되면 다른 UI 이벤트를 받지 않도록 설정
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //드래그가 종료되면 가지고 있던 아이템의 정보를 비워줌
        draggingitem = null;
        //드래그가 종료되면 다른 UI 이벤트를 받도록 설정
        canvasGroup.blocksRaycasts = true;
        //슬롯에 드래그하지 않았을 경우에 원래의 itemList로 이동
        if (itemTr.parent == inventotyTr)
            itemTr.SetParent(itemListTr.transform);

    }
}
