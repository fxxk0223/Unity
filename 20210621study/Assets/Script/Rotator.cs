using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    float rotate_speed = 40;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, rotate_speed * Time.deltaTime, 0);
    }

    //���������� ���̵��� �ٲٰ�ʹٸ�
    //���� ȸ���ӵ��� ������ ��濡�� �Ѿ��� ���ƿ����ϰų�
    //�Ѿ��� �߻��ֱ⸦ ª���ؼ� ���� �Ѿ��� �����ǰ� �ϰų�
    //�÷��̾��� ü���� �����ؼ� ��ȸ�� ���� �ְų�
    //�÷��̾��� �̵��ӵ��� �����ؼ� ���̵��� ������ �� �ִ�

    //�Ѿ��� ũ��, �Ѿ��� �ӵ��� �ٲ����νᵵ ���̵��� ������ �� ���� ���̴�
}
