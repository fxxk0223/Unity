using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    public GameObject expEffect;//���� ����Ʈ ������ ����
    int hitCount = 0;
    Rigidbody rb;

    public Mesh[] meshes;//����� ����ϴ� �޽�
    MeshFilter meshFilter;//�޽��� �������� �޽�����

    public Texture[] textures;//������ ��� �ؽ�ó
    MeshRenderer _renderer;//�ؽ�ó ������ �޽� �ؽ�ó

    public float expRadius = 10f;//���� �ݰ�


    AudioSource _audio;
    public AudioClip expSfx;

    public Shake shake;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        meshFilter = GetComponent<MeshFilter>();
        _renderer = GetComponent<MeshRenderer>();
        int idx = Random.Range(0, textures.Length);
        _renderer.material.mainTexture = textures[idx];

        _audio = GetComponent<AudioSource>();

        shake = GameObject.Find("CameraRig").GetComponent<Shake>();
;
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("BULLET"))
        {
            hitCount++;//�Ѿ��̶� �浹�ϸ� �浹Ƚ�� ����
            if(hitCount==3)
            {
                //���� ȿ�� �Լ� ȣ��
                ExpBarrel();
            }
        }
       
    }

    void ExpBarrel()
    {
        //���� ������ ���۵Ǵ� ���� effect��� ��ü(����) �̸��� �ο�����
        //���� effect��� ��ü���� ���ؼ� ���� ����
        GameObject effect= Instantiate(expEffect, transform.position, Quaternion.identity);
        //���� ���� �ð��� �ο�, 2�� �� ���� ����Ʈ ����
        Destroy(effect,2f);
        //rb.mass = 1f;
        //rb.AddForce(Vector3.up * 500f);
        IndirectDamage(transform.position);

        //��ϵ� �޽� �߿��� �ϳ��� �����ϱ� ���Ͽ� ������ ���ڸ� ����
        int idx = Random.Range(0, meshes. Length);
        //���� �ε����� �ش��ϴ� �޽��� �����ؼ� �޽����Ϳ� ����
        meshFilter.sharedMesh = meshes[idx];

        _audio.PlayOneShot(expSfx, 1f);

        StartCoroutine(shake.ShakeCamera(0.1f, 0.2f, 0.5f));

    }

    void IndirectDamage(Vector3 pos)
    {
        //OverlapSphere �޼ҵ�� ������ ���� ���ؼ� ���� �ȿ� �ִ� ��� ������Ʈ�� ��� �����ؼ� ������ ��

        Collider[] colls = Physics.OverlapSphere(pos, expRadius, 1 << 8);//2�� 8���� �ǹ�(����ġ ���ϴ� �ǹ�)
        //pos: ���� ����
        //expRidius//���� �ݰ�
        //1<<8: ������ �ִ� �ݰ�
        //OverlapSphere: ��ġ ���� ��+����


        //����� ������Ʈ�� ���������� �ϳ��� �����ϵ��� ��
        //1�� �����ϴ� for���� ������
        //��© ���� �� ����
        foreach (var coll in colls)
        {
            var _rb = coll.GetComponent<Rigidbody>();
            _rb.mass = 1;
            //�������� ���߷��� �ƴ϶� ���� �Ʒ��� ���߷��� �ֱ� ���ؼ� �����
            //AddExplosionForce (Ⱦ(����)���߷�, ���� ����, ���� �ݰ�, ��(����))
            _rb.AddExplosionForce(600f,pos,expRadius,500f);
            
        }
    }


    void Update()
    {
        
    }
}
