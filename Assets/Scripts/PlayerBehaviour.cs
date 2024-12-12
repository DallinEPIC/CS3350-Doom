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
    public override void Hit(int dmg)
    {
        _currentHealth -= dmg;
        if (_currentHealth <= 0) Die();
    }
    public void pickupHealth(int hp, bool overHealth) 
    {
        _currentHealth += hp;
        if(_currentHealth > _maxHealth && !overHealth) { _currentHealth = _maxHealth; }
        if (_currentHealth > _maxHealth * 2) { _currentHealth = _maxHealth * 2; }
    }
    public void pickupArmour(int amr, bool overArmour)
    {
        _currentArmour += amr;
        if (_currentArmour > _maxArmour && !overArmour) { _currentArmour = _maxArmour; }
        if (_currentArmour > _maxArmour * 2) { _currentArmour = _maxArmour * 2; }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Door"))
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                other.gameObject.GetComponent<DoorBehaviour>().Open();
            }
            
        }
    }
}
