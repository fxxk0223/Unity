using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;//스파크 프리팹



   // Start is called before the first frame update
   private void OnCollisionEnter(Collision collision)
        //충돌이 발생한 놈들 중에서 BULLET 태그만 검출
    {
        if (collision.collider.tag=="BULLET")

        {
            //스파크 이펙트 함수 호출
            ShowEffect(collision);

            //충돌이 발생한 오브젝트 삭제
            //Destroy(collision.gameObject);//죽였을 때 바로 없어지는 코드
            //Destroy(collision.gameObject,5f); //죽였을 때 서서히 없어지는 코드
            collision.gameObject.SetActive(false);
        }
    }

    void ShowEffect(Collision coll)

    {
        //충돌 지점의 정보를 가지고 옴
        //충돌 시 발생한 최초의 위치 정보
        ContactPoint contact = coll.contacts[0];
        //FromToRotation(회전 시키고자 하는 벡터, 타겟 벡터)햄버거 세트 메뉴~~~(정석적)
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, contact.normal);
        //충돌이 난 후 이펙트의 효과 방향 (z)를
        //법선 벡터 (총알이 날아온 방향 -z)방향으로 돌려서 생성함
        //총알이 발사된 위치로 이동(드럼통에서 조금 띄어서 총알 자국 생성)
        Vector3 point = contact.point + (-contact.normal * 0.05f);
        GameObject spark = Instantiate(sparkEffect, contact.point, rot); Instantiate(sparkEffect, contact.point, rot);
        //동적 생성된 이펙트의 부모로 드럼통을 설정
        spark.transform.SetParent(this.transform);
    }
}