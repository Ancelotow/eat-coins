using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speedX = 8.0f;
    public float speedY = 8.0f;
    public Score scoreManager;
    
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
        CatchTarget();
    }
    
    void CatchTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        foreach (var target in targets)
        {
            Coin coin = target.GetComponent<Coin>();
            if (coin.isFake)
            {
                scoreManager.Increment(-5);
            }
            else
            {
                scoreManager.Increment(coin.point);
            }
            float targetRadius = target.GetComponent<SpriteRenderer>().bounds.size.x / 2;
            if (Vector2.Distance(target.transform.position, transform.position) < targetRadius + radius)
            {
                Destroy(target);
            }
        }
    }
}
