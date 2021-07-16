using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down_Obs_Maker : MonoBehaviour
{
    public GameObject down_obs;
    
    float obs_delay;//���� �ֱ�
    float obs_timer;//���� �ð�
    void Start()
    {
        obs_delay = 2;
        obs_timer = 0;
    }

    void Update()
    {


        obs_timer += Time.deltaTime;
        if (obs_timer >= obs_delay)
        {
            obs_timer -= obs_delay;
            Instantiate(down_obs);
        }


        this.transform.position += Vector3.left * 4 * Time.deltaTime;
        if (this.transform.position.x <= -4)
        {
            Vector3 resetPos = this.transform.position;
            resetPos.x += 4;
            resetPos.y = Random.Range(-2, -0.1f);
            //���̸� �����ϰ�
            this.transform.position = resetPos;
            //������ ��ǥ�� ����

            //transform.position�� x,y,z����
            //���� ���� �ٲ� �� ���� ������
            //��ó�� ������ ������ �����ϰ�
            //��ġ�� ������ �ڿ� �ٽ� �����ְ� �ִ�


            this.transform.position += Vector3.right * 16;
            //������ ȭ������ �̵�
        }
    }
}

