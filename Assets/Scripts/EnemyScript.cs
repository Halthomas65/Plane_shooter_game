using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform []gunpoint;
    public GameObject enemyBullet;
    // public GameObject dmgEffect;
    public GameObject flash;
    public GameObject explosionPrefab;
    public Healthbar healthbar;
    public GameObject coinPrefab;

    public float fireRate = 0.5f;
    public float flashTime = 0.05f;
    public float speed = 1f;
    public float health = 10f;

    float barSize = 1f;
    float damage = 0;

    // Start is called before the first frame update
    void Start()
    {
        flash.SetActive(false);
        StartCoroutine(EnemyShooting());
        damage = barSize / health;  // Die in 10 hits (health = 10)
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
            DamageHealthbar();
            Destroy(collision.gameObject);

            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if (bullet != null && bullet.dmgEffect != null)
            {
                GameObject dmgVfx = Instantiate(bullet.dmgEffect, collision.transform.position, Quaternion.identity);
                Destroy(dmgVfx, 0.05f);
            }

            if (health <= 0)
            {
                Destroy(gameObject);
                GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
                GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(explosion, 0.5f);
            }

        }

        if (collision.gameObject.tag == "Player")
        {
            DamageHealthbar();
            
            if (health <= 0)
            {
                Destroy(gameObject);
                GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
                GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(explosion, 0.5f);
            }
        }
    }

    void DamageHealthbar()
    {
        if (health > 0)
        {
            health -= 1;
            barSize -= damage;
            healthbar.SetSize(barSize);
        }
    }

    void enemyFire()
    {
        for (int i = 0; i < gunpoint.Length; i++)
        {
            Instantiate(enemyBullet, gunpoint[i].position, Quaternion.identity);
        }
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
