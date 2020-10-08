using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float duration;

    public Action<Bomb> onRemove;
    private void Start()
    {
        StartCoroutine(DelayToRemove());
    }

    private IEnumerator DelayToRemove()
    {
        yield return new WaitForSeconds(duration);
        Remove();
    }

    private void Remove()
    {
        onRemove?.Invoke(this);
    }

    public void Delete()
    {
        Destroy(this.gameObject);
    }
}
