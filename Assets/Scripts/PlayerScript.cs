using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10;
    public float padding = 0.8f;    // padding to keep the player within the screen
    float minX;
    float maxX;
    float minY;
    float maxY;

    void FindBoundaries()
    {
        Camera gameCam = Camera.main;
        Vector3 min = gameCam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 max = gameCam.ViewportToWorldPoint(new Vector3(1, 1, 0));
        minX = min.x + padding;
        maxX = max.x - padding;
        minY = min.y + padding;
        maxY = max.y - padding;

        Debug.Log("minX: " + minX + " maxX: " + maxX + " minY: " + minY + " maxY: " + maxY);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        FindBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        float newXPos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        float newYPos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);

        transform.position = new Vector3(newXPos, newYPos, 0);
    }
}
