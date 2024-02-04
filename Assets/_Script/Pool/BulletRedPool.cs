using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class BulletRedPool : BulletPool
    {
        private static BulletRedPool _instance;
        public static BulletRedPool Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<BulletRedPool>();
                }
                return _instance;
            }
        }
    }
}
