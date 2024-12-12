using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField, Range(0, 100)] protected int _maxHealth;
    protected int _currentHealth;
    [SerializeField, Range(0, 100)] protected int _maxArmour;
    protected int _currentArmour;
    public AudioClip hurtSound, deathSound;
    void Start()
    {
        _currentHealth = _maxHealth;
    }
    public void Hit(int dmg)
    {
        GetComponent<AudioSource>().PlayOneShot(hurtSound);

        int armourDamage = dmg / 3; //Third of damage absorbed by armour
        dmg -= armourDamage;

        if (_currentArmour < armourDamage) //If not enough armour to 
        {
            armourDamage -= _currentArmour;
            _currentArmour = 0;
        }
        else
        {
            _currentArmour -= armourDamage;
            armourDamage = 0;
        }
        _currentHealth -= dmg + armourDamage;
        if (_currentHealth < 0) Die();
    }

    public virtual void Die() { GetComponent<AudioSource>().PlayOneShot(deathSound); }
}
