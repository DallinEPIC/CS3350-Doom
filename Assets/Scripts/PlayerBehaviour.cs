using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : CharacterBehaviour
{
    [HideInInspector] public static PlayerBehaviour instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        
    }
    public override void Die()
    {
        
    }
}
