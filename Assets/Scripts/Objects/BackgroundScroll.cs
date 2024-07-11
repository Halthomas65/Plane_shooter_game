using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
// using UnityEditor;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public Renderer meshRender;
    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        meshRender.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
        
    }
}
