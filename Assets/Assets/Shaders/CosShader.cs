using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CosShader : MonoBehaviour
{   

    public float TimeRematch;
    public float CosRematch;
    public Vector2 uvMainTex;

    void Start()
    {
        //uvMainTex = uv;
    }

    void Update()
    {
        //float OffsetX = Mathf.Cos(Time.time * Time.deltaTime * TimeRematch) * CosRematch + uvMainTex.x;
        
        //GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (OffsetX,uvMainTex.y);

    }

}
