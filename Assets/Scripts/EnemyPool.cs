using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    // Kich thước pool 
    [SerializeField] private uint initPoolsize = 5;
    // Các loại enemy
    public GameObject enemyPrefabs;

    // Created enemies
    [SerializeField] public GameObject[] enemies;
    // pool 
    [SerializeField] private Stack<GameObject> enemyStack;

    // Start is called before the first frame update
    void Start()
    {
        SetupPool();
    }


    void SetupPool()
    {
        enemyStack = new Stack<GameObject>();
        for (int i = 0; i < initPoolsize; i++)
        {
            GameObject enemy = SpawnEnemy();
            enemyStack.Push(enemy);
            enemy.SetActive(false); // Make inactive at start  to save resources.
        }
    }

    GameObject SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemies.Length);
        int randomX = Random.Range(-4, 4);
        return Instantiate(enemyPrefabs, new Vector2(randomX, transform.position.y), Quaternion.identity);
    }

    // Find Inactive enemy
    public GameObject GetEnemy()
    {
        if (enemyStack.Count == 0)
        {
            GameObject newEnemy = SpawnEnemy();
            return newEnemy;
        }
        else 
        {
            GameObject enemy = enemyStack.Pop();
            enemy.SetActive(true);
            return enemy;
        }
    }

    public void PutInPool(GameObject enemy)
    {
        enemy.SetActive(false);
        int randomX = Random.Range(-4, 4);
        enemy.transform.position =  new Vector2(randomX, transform.position.y); // Reset position
        enemyStack.Push(enemy);
    }
}
