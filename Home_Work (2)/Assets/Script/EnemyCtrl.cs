using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public GameObject _enemybullet;

    float bullet_delay;//���� �ֱ�
    float bullet_timer;//���� �ð�


    void Start()
    {
        StartCoroutine(BulletMaker());
        bullet_delay = 3.0f;//���� �ֱ�
        bullet_timer = 0;//���� �ð�

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
