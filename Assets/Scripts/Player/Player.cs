using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int score;

    public Action<int> scoreUpdated;
    public Action isDead;
    
    public void Collect(Food food)
    {
        score += Mathf.Abs(food.Collect());

        scoreUpdated?.Invoke(score);
    }

    public void Dead()
    {
        isDead?.Invoke();
    }
}
