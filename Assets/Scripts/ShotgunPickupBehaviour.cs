using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPickupBehaviour : ItemPickupBehaviour
{
    [SerializeField] private int _shotgunShells;
    public override void Pickup()
    {
        PlayerWeaponBehaivour.instance._hasShotgun = true;
        PlayerWeaponBehaivour.instance.pickupAmmo(0, _shotgunShells, 0);
    }
}
