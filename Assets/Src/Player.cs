using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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
    
    int Add(int x, int y)
    {
        return x + y;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            position.y += speedY * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            position.y += -speedY * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            position.x += speedX * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            position.x += -speedX * Time.deltaTime;
        }

        position.y = Math.Clamp(position.y, -screenLimitY + radius, screenLimitY - radius);
        position.x = Math.Clamp(position.x, -screenLimitX + radius, screenLimitX - radius);
        transform.position = position;
    }
}
