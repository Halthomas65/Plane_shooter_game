using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] clone;  // TODO: remove
    public float respawnTime = 3f;
    public int TotalSpawnCount = 10;    // TODO: remove

    public GameController gameController;
    private bool lastCloneSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (lastCloneSpawned && FindObjectOfType<EnemyScript>() == null)
        {
            StartCoroutine(gameController.LevelComplete());
        }
    }

    IEnumerator SpawnRoutine()
    {
        for (int i = 0; i < TotalSpawnCount; i++)
        {
            // GameObject clone = enemyPool.GetEnemy();  // TODO: replace with enemyPool.GetEnemy() when implemented
            SpawnClone();
            yield return new WaitForSeconds(respawnTime);
        }

        lastCloneSpawned = true;

        // gameController.LevelComplete();
    }

    void SpawnClone()
    {
        int randomIndex = Random.Range(0, clone.Length);
        int randomX = Random.Range(-4, 4);
        Instantiate(clone[randomIndex], new Vector2(randomX, transform.position.y), Quaternion.identity);
    }
}
