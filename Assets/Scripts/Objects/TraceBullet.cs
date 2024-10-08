using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceBullet : MonoBehaviour
{
    public float speed = 10;
    public GameObject dmgEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector2.up * Time.deltaTime * speed);
        GameObject target =  GameObject.Find("Enemy");
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        // transform.position = Vector2.Lerp(transform.position, target.position, speed * Time.deltaTime);
    }

    IEnumerator TrackEnemy()
    {
        GameObject target =  GameObject.Find("Enemy");
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        yield return new WaitForSeconds(0.5f);
    }
}
