using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    #region IDamageable
    public event Action Death;
    public int CurrentHealth { get; set; }
    public int MaxHealth { get; set; }

    private void Start()
    {
        CurrentHealth = MaxHealth;
        Death += OnDeath;

    }
    public void TakeDamage(int damage)
    {
        CurrentHealth = CurrentHealth - damage <= 0 ? 0 : CurrentHealth - damage;
        if (CurrentHealth == 0) Death?.Invoke();
    }
    public void OnDeath()
    {
        throw new NotImplementedException();
    }
    

    #endregion
    
}
