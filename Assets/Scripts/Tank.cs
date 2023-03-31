using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tank : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public virtual void TakeDamage(int damage) => _currentHealth -= damage;

    public virtual void TryDie() 
    {
        if(_currentHealth <= 0)
            gameObject.SetActive(false);
    }
}
