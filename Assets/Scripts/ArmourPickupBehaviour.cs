using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourPickupBehaviour : QuadBehaviour
{
    [SerializeField] private int _armour;
    [SerializeField] private bool _overArmour;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        PlayerBehaviour.instance.pickupArmour(_armour, _overArmour);
        gameObject.SetActive(false);
    }
}
