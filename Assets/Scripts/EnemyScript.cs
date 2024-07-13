using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform gunpoint1;
    public Transform gunpoint2;
    public GameObject enemyBullet;
    public GameObject flash;
    public GameObject explosionPrefab;
    public float fireRate = 0.5f;
    public float flashTime = 0.05f;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        flash.SetActive(false);
        StartCoroutine(EnemyShooting());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(gameObject);
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 0.5f);
        }
    }

    void enemyFire()
    {
        Instantiate(enemyBullet, gunpoint1.position, Quaternion.identity);
        Instantiate(enemyBullet, gunpoint2.position, Quaternion.identity);
    }

    IEnumerator EnemyShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            enemyFire();

            flash.SetActive(true);
            yield return new WaitForSeconds(flashTime);
            flash.SetActive(false);
        }
    }
}
