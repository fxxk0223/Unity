using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float eDlay;
    float dTimer;
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        eDlay = 2;
        dTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        dTimer += Time.deltaTime;

        if (dTimer >= eDlay)
        {
            dTimer -= eDlay;

            float enemySapwnRand = Random.Range(-8,8);
            Instantiate(enemyPrefab, new Vector3(enemySapwnRand, 6, 0),Quaternion.identity);
            //랜덤한 x좌표 위치에서 에너미를 생성한다

        }
    }
}
