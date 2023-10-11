using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speedX = 12.0f;
    public float speedY = 8.0f;
    private float screenLimitX, screenLimitY;
    private Vector2 position;
    private float radius;
    
    void Start()
    {
        Camera cam;
        cam = Camera.main;
        screenLimitX = cam.orthographicSize * cam.aspect;
        screenLimitY = cam.orthographicSize;
        position = transform.position;
        radius = GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

   

    void Update()
    {
        if (position.x + radius >= screenLimitX || position.x - radius <= -screenLimitX)
        {
            speedX = -speedX;
        }
        if (position.y + radius >= screenLimitY || position.y - radius <= -screenLimitY )
        {
            speedY = -speedY;
        }

        position.x += speedX * Time.deltaTime;
        position.y += speedY * Time.deltaTime;
        transform.position = -position;
    }
}
