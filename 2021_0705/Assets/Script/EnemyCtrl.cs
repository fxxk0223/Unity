using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public GameObject targetPos;
    public GameObject Enemy;
    public GameObject _EnemyBullet;
    float pressTime = 0;
    float delay = 1;
    public float enemy_LimitPos;
    public float enemy_movePos;
    public float enemy_movingSpeed;

    float enemy_delay;//���� �ֱ�
    float enemy_timer;//���� �ð�
  
    void Start()
    {
        enemy_delay = 2;
        enemy_timer = 0;
        Destroy(this.gameObject, 10.0f);//10�� �� enemy ����
    }

  
    void Update()
    {


        this.transform.position += Vector3.left * Time.deltaTime * enemy_movingSpeed;
        if (this.transform.position.x <= enemy_LimitPos)
        {
            this.transform.position += Vector3.right * enemy_movePos;
        }
        //enemy�� ������


        enemy_timer += Time.deltaTime;
        if (enemy_timer >= enemy_delay)
        {
            enemy_timer -= enemy_delay;

            Instantiate(_EnemyBullet, this.transform.position, Quaternion.identity);
            //enemy�� �Ѿ��� ��� ��ġ
        }
        //enemy�� �Ѿ��� ��� �Լ�

       
        

    }
}
