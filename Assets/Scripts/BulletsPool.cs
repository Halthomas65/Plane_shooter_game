using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : ObjectPooler
{
    private static BulletsPool _instance;

    public static BulletsPool Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<BulletsPool>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("BulletsPool");
                    _instance = container.AddComponent<BulletsPool>();
                }
            }

            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}