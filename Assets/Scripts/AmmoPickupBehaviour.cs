using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickupBehaviour : QuadBehaviour
{
    [SerializeField] private int _ammo, _shotgunShells, _rockets;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        PlayerWeaponBehaivour.instance.pickupAmmo(_ammo, _shotgunShells, _rockets);
        gameObject.SetActive(false);
    }
}
