using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner<T> : MonoBehaviour
{
    [SerializeField] protected Transform terrainTransform;
    [SerializeField] protected GameObject objectPrefab;
    
    [SerializeField] protected float duration;
    [SerializeField] protected float radius;
    [SerializeField] protected int maxCount;
    
    protected float _lastTime;
    protected List<T> _listObjects = new List<T>();

    public void Update()
    {
        if (_lastTime + duration < Time.time && _listObjects.Count < maxCount)
        {
            Spawn();
            _lastTime = Time.time;
        }
    }

    protected virtual void Spawn()
    {
        Vector3 pos = Random.onUnitSphere * radius;
        Quaternion rot = Quaternion.LookRotation((pos - terrainTransform.position).normalized);
        T obj = Instantiate(objectPrefab, pos, rot).GetComponent<T>();
        _listObjects.Add(obj);
    }

    protected virtual void Remove(T obj)
    {
        _listObjects.Remove(obj);
    }
}
