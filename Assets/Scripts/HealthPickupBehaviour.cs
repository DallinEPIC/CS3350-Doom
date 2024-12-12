using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HealthPickupBehaviour : ItemPickupBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private bool _overHealth;
    public override void Pickup()
    {
        PlayerBehaviour.instance.pickupHealth(_health, _overHealth);
    }
}
