using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform shootPoint1;
    public Transform shootPoint2;
    public GameObject flash;

    public float fireRate = 1f;
    public float flashTime = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        flash.SetActive(false);
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        // Fire();
    }

    void Fire()
    {
        Instantiate(playerBullet, shootPoint1.position, Quaternion.identity);
        Instantiate(playerBullet, shootPoint2.position, Quaternion.identity);
    }

    IEnumerator Shoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(fireRate);
            Fire();
            
            flash.SetActive(true);
            yield return new WaitForSeconds(flashTime);
            flash.SetActive(false);
        }
    }
}
