using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public GameObject _enemybullet;

    float bullet_delay;//생성 주기
    float bullet_timer;//지난 시간


    void Start()
    {
        StartCoroutine(BulletMaker());
        bullet_delay = 3.0f;//생성 주기
        bullet_timer = 0;//지난 시간

    }

   

    IEnumerator BulletMaker()
    {
        while (true)
        {
            var obj = Instantiate(_enemybullet, this.transform.position, Quaternion.identity);
            obj.transform.forward = transform.forward;

            yield return new WaitForSeconds(1f);
        }
    }

}
