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
        //3�ʿ� �ϳ��� ������ ����
        timer = 0;
        //0�ʺ��� ī��Ʈ�ٿ� ����
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= delay)
        {
            timer -= delay;

            float height = Random.Range(-1.2f,1.2f);
            //���� ������ ���� ��

            Instantiate(starGold, new Vector3(8, height, -2), Quaternion.identity);
            //if�� �ȿ� Instantiate �ֱ�
        }

        timer += Time.deltaTime;
        if (timer >= delay)
        {
            timer -= delay;

            float height = Random.Range(-1.2f, 1.2f);
            //���� ������ ���� ��

            Instantiate(starBronze, new Vector3(8, height, -2), Quaternion.identity);
            //if�� �ȿ� Instantiate �ֱ�
        }

        timer += Time.deltaTime;
        if (timer >= delay)
        {
            timer -= delay;

            float height = Random.Range(-1.2f, 1.2f);
            //���� ������ ���� ��

            Instantiate(starSilver, new Vector3(8, height, -2), Quaternion.identity);
            //if�� �ȿ� Instantiate �ֱ�
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
