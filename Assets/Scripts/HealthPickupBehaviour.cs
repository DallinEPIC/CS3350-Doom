using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HealthPickupBehaviour : QuadBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private bool _overHealth;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        PlayerBehaviour.instance.pickupHealth(_health, _overHealth);
        gameObject.SetActive(false);
    }
}
