using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourPickupBehaviour : ItemPickupBehaviour
{
    [SerializeField] private int _armour;
    [SerializeField] private bool _overArmour;
    public override void Pickup()
    {
         PlayerBehaviour.instance.pickupArmour(_armour, _overArmour);
    }
}
