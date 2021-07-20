using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    float iniHp = 100f;//초기 설정 체력

    public GameObject hpBarPrefab;
    public Vector3 hpBaroffset = new Vector3(0, 2.2f, 0);
    Canvas uiCanvas;//부모가 될 캔버스 객체
    Image hpBarImage;//생명력 수치

    const string bulletTag = "BULLET";

    float hp = 100f;//체력
    GameObject bloodEffect;//혈흔 효과

   
    void Start()
    {
        //Load 함수는 예약 폴더인 Recources에서 데이터를 불러오는 함수임
        //Load<데이터 유형>("파일의 경로")
        //최상위 경로는 Resources 폴더임 ex)C드라이브
        //파일의 경로는 하위 폴더명 + 파일명까지 정확하게 풀경로를 명시
        bloodEffect = Resources.Load<GameObject>("Blood");//위치 정확히 명시하기
        //체력바 설정 함수 호출
        SetHpBar();



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == bulletTag)
        {
            //혈흔 효과 함수 호출
            ShowBloodEffect(collision);

            //총알 삭제
            //Destroy(collision.gameObject);

            collision.gameObject.SetActive(false);
            hp -= collision.gameObject.GetComponent<Bulletctrl>().damage;//총알마다 데미지가 다를 수도 있기 때문에 데미지를 넣어준다(특수탄환)

            hpBarImage.fillAmount = hp / iniHp;

            //때리는 쪽에 데미지를 넣기
            //체력이 0 이하가 되면 적이 죽었다고 판단
            if(hp<=0)//겜 만들 때는 잘 '==' 안 씀
            {
                //상태 변화 해줌
                GetComponent<EnemyAI>().state = EnemyAI.State.DIE;
                hpBarImage.GetComponentsInParent<Image>()[1].color=Color.clear;
            }
        }
    }


    void SetHpBar()
    {
        uiCanvas = GameObject.Find("UICanvas").GetComponent<Canvas>();
        //uiCanvas의 자식으로 hpBar프리팹 동적 생성
        GameObject hpBar = Instantiate(hpBarPrefab, uiCanvas.transform);
        hpBarImage = hpBar.GetComponentsInChildren<Image>()[1];

        var _hpBar = hpBar.GetComponent<EnemyHpBar_>();
        //_hpBar가 추적해야할 대상으로 Enemy 지정
        _hpBar.targetTr = gameObject.transform;
        _hpBar.offset = hpBaroffset;




    }


    //총알 맞은 부위에 피가 나오게 하겠다는 의미 
    void ShowBloodEffect(Collision coll)
    {
        Vector3 pos = coll.contacts[0].point;
        //충돌 위치의 법선 벡타(총알이 날라온 방향)구하기
        Vector3 _nomal = coll.contacts[0].normal;
        //총알이 날라온 방향값 계산
        Quaternion rot = Quaternion.FromToRotation(Vector3.back, _nomal);
        GameObject blood = Instantiate<GameObject>(bloodEffect, pos, rot);
        //1초 후 삭제
        Destroy(blood, 1f);
    }


    void Update()
    {
        
    }
}
