using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] protected float shootInterval;
        [SerializeField] protected float lastShootTimestamp;
        [SerializeField] protected Transform startPosition;

        [SerializeField] protected BulletPool bulletPool;

        private void Start()
        {
            StartCoroutine(bulletPool.Init());
        }
        public abstract void Shoot(Quaternion rotation);

    }
}
