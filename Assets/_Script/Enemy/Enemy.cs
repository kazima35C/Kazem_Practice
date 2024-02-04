using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected Health health;
        [SerializeField] protected int damage;
        [SerializeField] protected float speed;

        [SerializeField] protected LayerMask layerMask;
        [SerializeField] protected Material material;
        // [SerializeField] protected GameObject deathEffect;

        public abstract void UpdateEnemy();
        private void OnCollisionEnter(Collision other)
        {
            if (((1 << other.gameObject.layer) & layerMask) != 0)
            {
                other.transform.GetComponent<Health>().TakeDamage(damage);
            }
        }

        protected void Die()
        {
            GameManager.Instance.enemyKilled.Value++;
            // GameManager.Instance.enemyKilledss;
            EnemyManager.Instance.RemoveEnemy(this);
            Particle effectDeath = EffectPool.Instance.GetParticle();
            effectDeath.Init(transform.position, transform.rotation, material);
            Destroy(gameObject);
        }
    }
}
