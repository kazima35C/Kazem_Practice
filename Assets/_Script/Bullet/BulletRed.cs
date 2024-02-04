using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class BulletRed : Bullet
    {
        public override void Shoot()
        {
            rg.AddForce(transform.forward * speed, ForceMode.Impulse);
            StopCoroutine(EndTimeLife());
            StartCoroutine(EndTimeLife());
        }

        public override IEnumerator EndTimeLife()
        {
            yield return new WaitForGameSeconds(timeLife);
            BulletRedPool.Instance.ReturnBullet(this);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (((1 << other.gameObject.layer) & layerMask) != 0)
            {
                other.transform.GetComponent<Health>().TakeDamage(damage);
                BulletRedPool.Instance.ReturnBullet(this);
            }
        }
    }
}
