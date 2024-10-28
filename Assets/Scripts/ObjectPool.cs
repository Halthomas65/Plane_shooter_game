using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab; // prefab to pool
    public int poolSize = 10;
    public string poolId;

    [SerializeField] private List<GameObject> pool;

    // Start is called before the first frame update
    void Start()
    {
        InitializePool();
    }
    void FixedUpdate()
    {
        // If more than 1.5 times the pool size is active, clear the pool to save memory
        if (pool.Count > 1.5 * poolSize)
        {
            CleanPool();
        }
    }

    void InitializePool()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            CreateNewObj();
        }
    }

    GameObject CreateNewObj()
    {
        GameObject obj = Instantiate(prefab, transform);
        obj.SetActive(false);
        pool.Add(obj);

        return obj;
    }

    public GameObject GetPooledObject()
    {
        Debug.Log("GetPooledObject");

        foreach (GameObject obj in pool)
        {
            Debug.Log("Iterating through objects");

            // Check for inactive object
            if (!obj.activeInHierarchy)
            {
                Debug.Log("Object inactive");
                return obj;
            }
        }

        // If no inactive object found, create a new one
        return CreateNewObj();
    }

    // Clean the pool if there's too many inactive objects
    public void CleanPool()
    {
        for (int i = pool.Count - 1; i >= poolSize; i--)
        {
            // Check for inactive object
            if (!pool[i].activeInHierarchy)
            {
                Destroy(pool[i]);
                pool.RemoveAt(i);
            }
        }
    }

    void ReturnToPool(GameObject obj)
    {
    }

}
