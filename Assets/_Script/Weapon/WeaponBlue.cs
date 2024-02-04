using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class WeaponBlue : PlayerWeapon
    {
        public Bullet bullet;
        public override void Shoot(Quaternion rotation)
        {
            if (lastShootTimestamp > Time.time)
            {
                return;
            }
            Bullet newBullet = bulletPool.GetBullet();
            newBullet.transform.SetPositionAndRotation(startPosition.position, rotation);
            newBullet.Shoot();
            lastShootTimestamp = Time.time + shootInterval;
        }
    }
}
