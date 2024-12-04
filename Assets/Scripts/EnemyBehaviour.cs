using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : CharacterBehaviour
{
    public override void Die()
    {
        GetComponent<EnemyWeaponBehaviour>().enabled = false;
        GetComponent<AIChaseBehaviour>().enabled = false;
        this.enabled = false;
    }
}
