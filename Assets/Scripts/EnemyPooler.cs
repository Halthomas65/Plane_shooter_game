using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : ObjectPooler
{
    public GameObject[] enemyPrefabs;    // enemy types
    // public EnemyFactory enemyFactory;

    public int TotalSpawnCount = 5;
    public GameController gameController;
    private bool lastCloneSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    void FixedUpdate()
    {
        if (lastCloneSpawned && FindObjectOfType<EnemyScript>() == null)
        {
            StartCoroutine(gameController.LevelComplete());
        }
    }

    IEnumerator SpawnCoroutine()
    {
        for (int i = 0; i < TotalSpawnCount; i++)
        {
            SpawnObject();

            yield return new WaitForSeconds(spawnInterval);
        }

        lastCloneSpawned = true;
    }

    void SpawnObject()
    {
        int randomX = Random.Range(-4, 4);  //random spawn position

        int randomIndex = Random.Range(0, enemyPrefabs.Length);   // random enemy type to pool

        // string enemyType = prefabs[randomIndex].name; // Assuming the prefab name corresponds to the enemy type
        // Enemy enemy = enemyFactory.CreateEnemy(enemyType);

        this.pool.prefab = enemyPrefabs[randomIndex];
        GameObject enemy = pool.GetPooledObject();

        enemy.transform.position = new Vector2(randomX, transform.position.y);
        enemy.transform.rotation = Quaternion.identity;
        enemy.SetActive(true);
    }
}

// // Common superclass for enemies
// public abstract class Enemy : MonoBehaviour
// {
//     // Common properties and methods for enemies
// }

// // Concrete enemy classes
// public class NormalEnemy : Enemy
// {

// }

// public class FastEnemy : Enemy
// {
//     // Fast enemy specific properties and methods
// }

// public class StrongEnemy : Enemy
// {
//     // Strong enemy specific properties and methods
// }

// // Factory class for creating enemies
// public class EnemyFactory
// {
//     public Enemy CreateEnemy(string enemyType)
//     {
//         switch (enemyType)
//         {
//             case "Fast":
//                 return new FastEnemy();
//             case "Strong":
//                 return new StrongEnemy();
//             default:
//                 return new NormalEnemy();
//                 //     throw new ArgumentException("Invalid enemy type");
//         }
//     }
// }
