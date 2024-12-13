using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponBehaviour : WeaponBehaviour
{
    [SerializeField] private float _cooldownTimer;
    private float _timer;

    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, PlayerBehaviour.instance.transform.position - transform.position, out hit);
        if (hit.transform.tag != "Player") { _timer = 0; return; }

        _timer += Time.deltaTime;

        if (_timer >= _cooldownTimer)
        {
            _timer %= _cooldownTimer;
            //_timer = 0;

            Physics.Raycast(transform.position, PlayerBehaviour.instance.transform.position - transform.position, out hit);
            FireWeapon(hit);
        }
    }
}
