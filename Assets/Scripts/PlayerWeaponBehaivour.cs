using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerWeaponBehaivour : WeaponBehaviour
{
    [HideInInspector] public static PlayerWeaponBehaivour instance;
    [HideInInspector] public bool _hasShotgun, _hasRocketLauncher;
    private int _ammo, _shotgunShells, _rockets, _currentWeapon;
    
    [SerializeField] private int _maxAmmo, _maxShotgunShells, _maxRockets;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        _ammo = 100;
    }
    void Update()
    {
        //Change weapons
        if (Input.GetKey(KeyCode.Alpha1))
        {
            _currentWeapon = 0;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            if (_hasShotgun)
            {
                _currentWeapon = 1;
            }
        }
        //Shoot Gun
        if (Input.GetMouseButtonDown(0))
        {
            if (_ammo < 1) return;
            _ammo -= 1;
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                UIPistolAnimation.instance.PlayGunShot();
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
    public int GetAmmo() { return _ammo; }
}
