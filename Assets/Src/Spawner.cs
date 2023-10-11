using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] targets;
    public float waitTime = 2.0f;
    private float timer = 0.0f;
    private float screenLimitX, screenLimitY;
    
    void Start()
    {
        Camera cam;
        cam = Camera.main;
        screenLimitX = cam.orthographicSize * cam.aspect;
        screenLimitY = cam.orthographicSize;
        CreateTarget();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            timer = 0.00f;
            CreateTarget();
        }
    }

    void CreateTarget()
    {
        Camera cam;
        cam = Camera.main;
        float x = Random.Range(-screenLimitX, screenLimitX);
        float y = Random.Range(-screenLimitY, screenLimitY);

        Vector2 position = new Vector2(x, y);
        int randomNumber = Random.Range(0, targets.Length);
        Instantiate(targets[randomNumber], position, Quaternion.identity);
    }
}
