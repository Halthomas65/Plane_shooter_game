using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    public float respawnTime = 2f;
    public int enemySpawnCount = 10;

    public GameController gameController;
    private bool lastEnemySpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (lastEnemySpawned && FindObjectOfType<EnemyScript>() == null)
        {
            StartCoroutine(gameController.LevelComplete());
        }
    }

    IEnumerator SpawnEnemyRoutine()
    {
        for (int i = 0; i < enemySpawnCount; i++)
        {
            SpawneEnemy();
            yield return new WaitForSeconds(respawnTime);
        }

        lastEnemySpawned = true;

        // gameController.LevelComplete();
    }

    void SpawneEnemy()
    {
        int randomIndex = Random.Range(0, enemy.Length);
        int randomX = Random.Range(-4, 4);
        GameObject newEnemy = Instantiate(enemy[randomIndex], new Vector2(randomX, transform.position.y), Quaternion.identity);
    }
}
