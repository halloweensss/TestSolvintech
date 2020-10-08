using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BombTrigger : MonoBehaviour
{
    [SerializeField] private Player player;
    private void OnTriggerEnter(Collider other)
    {
        Bomb bomb;
        if (other.TryGetComponent<Bomb>(out bomb))
        {
            player.Dead();
        }
    }
}
