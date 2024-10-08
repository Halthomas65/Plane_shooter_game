using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public Transform bar;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     // SetSize(0.5f);
    // }

    public void SetSize(float size)
    {
        bar.localScale = new Vector2(size, 1f);
    }
}
