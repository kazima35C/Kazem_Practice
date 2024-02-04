using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 10;
        [SerializeField] private int currentHealth;
        public int CurrentHealth => currentHealth;
        public bool IsDead => currentHealth <= 0;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
        }

    }
}
