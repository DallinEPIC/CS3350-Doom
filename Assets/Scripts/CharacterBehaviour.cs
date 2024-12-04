using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField, Range(0, 10)] protected int _maxHealth;
    protected int _currentHealth;
    void Start()
    {
        _currentHealth = _maxHealth;
    }
    public void Hit()
    {
        _currentHealth -= 1;
        if (_currentHealth <= 0) Die();
    }

    public virtual void Die()
    {
        
    }
}
