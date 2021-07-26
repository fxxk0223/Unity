using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    //����ũ ȿ���� �༭ ���Ÿ� ī�޶��� Ʈ������
    public Transform shakeCamera;
    //ȸ�� ��ų�� ���� �Ǵ��ϴ� ����
    public bool shakeRotate = false;
    Vector3 originPos;//���� ��ġ
    Quaternion originRot;//���� ȸ����
    
    void Start()
    {
        originPos = shakeCamera.localPosition;
        originRot = shakeCamera.localRotation;
    }

    public IEnumerator ShakeCamera(float duration = 0.05f, float mPos = 0.03f, float mRot = 0.1f)//ȸ�� ��ų ���� �Լ�
    {
        //��� �ð� ����� ����
        float passTime = 0f;
        //������ ���� �ð����ȸ� ��鸮���� ����
        while (passTime < duration)
        {
            //�������� 1�� ������ ��ü ��翡�� ��ǥ�� ����
            //(x,y,z)�� �ּ� (-1,-1,-1)~(1,1,1) ������ ���� ����
            Vector3 shakePos = Random.insideUnitSphere;//������ ��鸲 ȿ�� ���� �� ��

            //������ ������ ��ġ ���� ���� ī�޶��� ��ġ�� ��������
            shakeCamera.localPosition = shakePos * mPos;

            //ī�޶� ȸ���� ��ų ���
            if(shakeRotate)
            {
                //�޸� ������� ����Ģ���� ����� ������� ������
                //�ϰ����� �ִ� ������ ���¸� ���� ����� �߻�
                //���� ��Ģ���� �ֵ��� ���̰� ��
                //�����̳� �繰�� ��ġ�� �� ���� ���Ǹ�
                //��; ���� �ʵ忡 �ִ� ������ Ǯ ���� ���� �� ���� ����
                float noise = Mathf.PerlinNoise(Time.time * mRot, 0f);//���� �����ϰ� �׸� �� ���� (�׳��� ��Ģ���̳� ������ �ұ�Ģ��)
                Vector3 shakeRot = new Vector3(0, 0, noise) ;
                //������ ���� ȸ������ ī�޶� ����
                shakeCamera.localRotation = Quaternion.Euler(shakeRot);
            }
            passTime += Time.deltaTime;
            yield return null;
        }
        //���� �Ŀ� ī�޶��� ��ġ�� ȸ������ �ʱ갪���� �ٽ� ����
        shakeCamera.localPosition = originPos;
        shakeCamera.localRotation = originRot;
    }

    
    void Update()
    {
        
    }
}
