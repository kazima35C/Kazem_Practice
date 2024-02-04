using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class BulletBluePool : BulletPool
    {
        private static BulletBluePool _instance;
        public static BulletBluePool Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<BulletBluePool>();
                }
                return _instance;
            }

        }

    }
}
