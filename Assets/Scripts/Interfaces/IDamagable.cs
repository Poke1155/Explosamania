using System;
using UnityEngine;

public interface IDamageable
{
    event Action Death;
    void TakeDamage(int damage);
    void OnDeath();
}
