using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerWeaponBehaivour : WeaponBehaviour
{
    [HideInInspector] public static PlayerWeaponBehaivour instance;
    private int _ammo, _shotgunShells, _rockets;
    [SerializeField] private int _maxAmmo, _maxShotgunShells, _maxRockets;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                FireWeapon(hit);
            }
        }
    }
    public void pickupAmmo(int ammo, int shells, int rockets)
    {
        _ammo += ammo;
        if (ammo >  _maxAmmo) { _ammo = _maxAmmo; }
        _shotgunShells += shells;
        if (shells > _maxShotgunShells) { _shotgunShells = _maxShotgunShells; }
        _rockets += rockets;
        if (_rockets > _maxRockets) { _rockets = _maxRockets; }
    }

}
