using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // multiple enemy types, each type is stored in  a separate pool
    public ObjectPooler[] enemyPools;
    public float spawnInterval = 3f;

    public int TotalSpawnCount = 10;
    public GameController gameController;
    private bool lastCloneSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }

    void FixedUpdate()
    {
        if (lastCloneSpawned && FindObjectOfType<EnemyScript>() == null)
        {
            StartCoroutine(gameController.LevelComplete());
        }
    }

    IEnumerator SpawnEnemyCoroutine()
    {
        for (int i = 0; i < TotalSpawnCount; i++)
        {
            SpawnObj();

            yield return new WaitForSeconds(spawnInterval);
        }

        lastCloneSpawned = true;
    }

    void SpawnObj()
    {
        int randomX = Random.Range(-4, 4);  //random spawn position

        int randomIndex = Random.Range(0, enemyPools.Length);   // random enemy type to pool
        GameObject enemy = enemyPools[randomIndex].GetPooledObject();

        enemy.transform.position = new Vector2(randomX, transform.position.y);
        enemy.transform.rotation = Quaternion.identity;
        enemy.SetActive(true);
    }
}