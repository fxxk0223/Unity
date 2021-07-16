using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    public GameObject Enemy;


    public float enemy_delay = 2;
    public float enemy_timer = 0;


    void Start()
    {
        enemy_delay = 2;
        enemy_timer = 0;
    }

    void Update()
    {
        enemy_timer += Time.deltaTime;
        if (enemy_timer >= enemy_delay)
        {
            enemy_timer -= enemy_delay;

            float height = Random.Range(5f, -0.1f);
            //Enemy가 랜덤하게 생성 될 높이 값

            Instantiate(Enemy, new Vector3(8, height, -2), Quaternion.identity);
        }

    }
}
