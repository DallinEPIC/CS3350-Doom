using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : CharacterBehaviour
{
    [SerializeField] private Material _deadMaterial;
    public override void Die()
    {
        base.Die();
        GetComponent<EnemyWeaponBehaviour>().enabled = false;
        GetComponent<AIChaseBehaviour>().enabled = false;
        GetComponent<MeshRenderer>().material = _deadMaterial;
        this.enabled = false;
    }
}
