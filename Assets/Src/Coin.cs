using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private readonly float timerDestroy = 5.0f;
    public bool isFake = false;
    public int point = 1;
    
    void Start()
    {
        Destroy(gameObject, timerDestroy);

    }

   

    void Update()
    {
    }
}
