using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMove : MonoBehaviour
{
    public Material mat;

    public float speed;
    Vector2 offset;

    void Start()
    {
        mat = this.GetComponent<SpriteRenderer>().material;

    }

    void Update()
    {
        offset = mat.mainTextureOffset;

        offset.x += Time.deltaTime*2;
       
        mat.mainTextureOffset = offset;

    }
}

