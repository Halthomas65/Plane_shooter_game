using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public ObjectPooler bulletPool;
    // public GameObject playerBullet;
    public Transform[] shootPoints;
    public GameObject flash;

    public float fireRate = 0.5f;
    public float flashTime = 0.05f;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        flash.SetActive(false);
        StartCoroutine(Shoot());
    }

    void Fire()
    {
        for (int i = 0; i < shootPoints.Length; i++)
        {
            // Instantiate(playerBullet, shootPoints[i].position, Quaternion.identity);
            GameObject bullet = bulletPool.GetPooledObject();
            bullet.transform.position = shootPoints[i].position;
            bullet.transform.rotation = shootPoints[i].rotation;
            bullet.SetActive(true);
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            Fire();

            audioSource.Play();

            flash.SetActive(true);
            yield return new WaitForSeconds(flashTime);
            flash.SetActive(false);
        }
    }
}
