using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : Spawner<Bomb>
{
    protected override void Spawn()
    {
        Vector3 pos = Random.onUnitSphere * radius;
        Quaternion rot = Quaternion.LookRotation((pos - terrainTransform.position).normalized);
        Bomb bomb = Instantiate(objectPrefab, pos, rot).GetComponent<Bomb>();
        
        bomb.onRemove += Remove;
        _listObjects.Add(bomb);
    }

    protected override void Remove(Bomb bomb)
    {
        bomb.onRemove -= Remove;
        
        _listObjects.Remove(bomb);
        bomb.Delete();
    }
}
