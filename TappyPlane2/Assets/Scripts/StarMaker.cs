using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMaker : MonoBehaviour
{
    public GameObject starGold;
    public GameObject starBronze;
    public GameObject starSilver;
    public GameObject BadPlane;
    public GameObject Heal;

    float delay;
    float timer;
    float height;


    void Start()
    {
        delay = 3;
        //3초에 하나씩 아이템 생성
        timer = 0;
        //0초부터 카운트다운 시작
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= delay)
        {
            timer -= delay;

            float height = Random.Range(-1.2f,1.2f);
            //별이 생성될 높이 값

            Instantiate(starGold, new Vector3(8, height, -2), Quaternion.identity);
            //if문 안에 Instantiate 넣기
        }

        timer += Time.deltaTime;
        if (timer >= delay)
        {
            timer -= delay;

            float height = Random.Range(-1.2f, 1.2f);
            //별이 생성될 높이 값

            Instantiate(starBronze, new Vector3(8, height, -2), Quaternion.identity);
            //if문 안에 Instantiate 넣기
        }

        timer += Time.deltaTime;
        if (timer >= delay)
        {
            timer -= delay;

            float height = Random.Range(-1.2f, 1.2f);
            //별이 생성될 높이 값

            Instantiate(starSilver, new Vector3(8, height, -2), Quaternion.identity);
            //if문 안에 Instantiate 넣기
        }


        timer += Time.deltaTime;
        if (timer >= delay)
        {
            timer -= delay;

            float height = Random.Range(-1.2f, 1.2f);
            

            Instantiate(BadPlane, new Vector3(8, height, -2), Quaternion.identity);
          
        }

        timer += Time.deltaTime;
        if (timer >= delay)
        {
            timer -= delay;

            float height = Random.Range(-1.2f, 1.2f);


            Instantiate(Heal, new Vector3(8, height, -2), Quaternion.identity);

        }



    }
}
