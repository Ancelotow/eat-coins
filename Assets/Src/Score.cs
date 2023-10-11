using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score = 0;

    public void Increment(int inc = 10)
    {
        score += inc;
        Display();
    }

    void Display()
    {
        Debug.Log(score);
    }
}
