using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private int score;

    public Action<Food> onCollected;
    public int Collect()
    {
        onCollected?.Invoke(this);
        return score;
    }

    public void Delete()
    {
        Destroy(this.gameObject);
    }
}
