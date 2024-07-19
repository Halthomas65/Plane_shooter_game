using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawner : MonoBehaviour
{
    public GameObject[] clone;
    public float respawnTime = 10f;
    public int TotalSpawnCount = 5;

    public GameController gameController;
    // private bool lastCloneSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnRoutine()
    {
        // for (int i = 0; i < TotalSpawnCount; i++)
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnClone();
        }
    }

    void SpawnClone()
    {
        int randomIndex = Random.Range(0, clone.Length);
        int randomX = Random.Range(-4, 4);
        Instantiate(clone[randomIndex], new Vector2(randomX, transform.position.y), Quaternion.identity);
    }
}
