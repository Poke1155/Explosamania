using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        public event Action Death;
        [SerializeField] private int maxHealth;
        private int currentHealth;

        private void Start()
        {
            currentHealth = maxHealth;
            Death += OnDeath;
        }

        public void OnDeath()
        {
            Debug.Log("bro is dead");
        }

        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage <= 0 ? 0 : currentHealth - damage;
            Debug.Log(currentHealth);
            if (currentHealth == 0) Death?.Invoke();
        }
        
    }
}