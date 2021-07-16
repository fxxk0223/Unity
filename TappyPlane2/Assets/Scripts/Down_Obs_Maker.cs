using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down_Obs_Maker : MonoBehaviour
{
    public GameObject down_obs;
    
    float obs_delay;//생성 주기
    float obs_timer;//지난 시간
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
            //높이를 랜덤하게
            this.transform.position = resetPos;
            //설정된 좌표를 대입

            //transform.position의 x,y,z값을
            //각각 따로 바꿀 수 없기 때문에
            //위처럼 별도의 변수에 저장하고
            //수치를 수정한 뒤에 다시 고쳐주고 있다


            this.transform.position += Vector3.right * 16;
            //오른쪽 화면으로 이동
        }
    }
}

