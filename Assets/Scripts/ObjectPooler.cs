using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Spawn and manage objects in the scene
public class ObjectPooler : MonoBehaviour
{
    public ObjectPool pool;
    public float spawnInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        SpawnObject();
        yield return new WaitForSeconds(spawnInterval);
    }

    void SpawnObject()
    {
        GameObject newObject = pool.GetPooledObject();

        newObject.transform.position = new Vector2(transform.position.x, transform.position.y);
        newObject.transform.rotation = Quaternion.identity;
        newObject.SetActive(true);
    }

    void DeactivateObject()
    {
        this.gameObject.SetActive(false);
    }
}
