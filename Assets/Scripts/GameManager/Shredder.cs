using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "PlayerBullet")
        {
            collision.gameObject.SetActive(false);
        }
        else
            Destroy(collision.gameObject);
    }
}
