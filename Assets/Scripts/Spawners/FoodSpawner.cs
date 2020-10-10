using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodSpawner : Spawner<Food>
{
    protected override void Spawn()
    {
        Vector3 pos = Random.onUnitSphere * radius;
        Quaternion rot = Quaternion.LookRotation((pos - terrainTransform.position).normalized);
        Food food = Instantiate(objectPrefab, pos, rot).GetComponent<Food>();
        
        food.onCollected += Remove;
        _listObjects.Add(food);
    }

    protected override void Remove(Food food)
    {
        food.onCollected -= Remove;
        _listObjects.Remove(food);
        food.Delete();
    }
}
