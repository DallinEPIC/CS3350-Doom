using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField, Range(0, 100)] protected int _maxHealth;
    protected int _currentHealth;
    [SerializeField, Range(0, 100)] protected int _maxArmour;
    protected int _currentArmour;
    void Start()
    {
        _currentHealth = _maxHealth;
    }
    public virtual void Hit(int dmg) {}

    public virtual void Die() {}
}
