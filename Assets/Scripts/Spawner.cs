using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject []enemy;
    public float respawnTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawneEnemyRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawneEnemyRoutine()
    {
        while (true)
        {
            SpawneEnemy();
            yield return new WaitForSeconds(respawnTime);
        }
    }

    void SpawneEnemy()
    {
        int randomIndex = Random.Range(0, enemy.Length);
        int randomX = Random.Range(-4, 4);
        GameObject newEnemy = Instantiate(enemy[randomIndex], new Vector2(randomX, transform.position.y), Quaternion.identity);
    }
}
