using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollectAbility : MonoBehaviour
{
    [SerializeField] private Player player;
    private void OnTriggerEnter(Collider other)
    {
        Food food;
        if (other.TryGetComponent<Food>(out food))
        {
            player.Collect(food);
        }
    }
}
