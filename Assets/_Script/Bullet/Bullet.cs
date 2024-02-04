using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] protected Rigidbody rg;
        [SerializeField] protected float speed = 50;
        [SerializeField] protected int damage = 5;
        [SerializeField] protected float timeLife = 3;
        [SerializeField] protected LayerMask layerMask;
        private Vector3 tempVelocity;
        public abstract void Shoot();
        public abstract IEnumerator EndTimeLife();
        public void Reset()
        {
            rg.velocity = Vector3.zero;
            tempVelocity = rg.velocity;
            gameObject.SetActive(false);
        }
        private void Start()
        {
            if (TimeManager.Instance.IsPause.Value)
            {
                    rg.velocity =tempVelocity;
            }
            TimeManager.Instance.IsPause.OnChange += () =>
            {
                if (TimeManager.Instance.IsPause.Value)
                {
                    tempVelocity = rg.velocity;
                    rg.velocity = Vector3.zero;
                    return;
                }
                    rg.velocity =tempVelocity;
            };
        }

    }
}
