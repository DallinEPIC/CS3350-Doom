using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickupBehaviour : ItemPickupBehaviour
{
    [SerializeField] private int _ammo, _shotgunShells, _rockets;
    public override void Pickup()
    {
        PlayerWeaponBehaivour.instance.pickupAmmo(_ammo, _shotgunShells, _rockets);
    }
}
