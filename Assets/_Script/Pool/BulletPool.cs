using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class BulletPool : MonoBehaviour
    {

        [SerializeField] protected Bullet bullet;
        [SerializeField] protected List<Bullet> listBullet;
        [SerializeField] protected int maxBulletCount = 20;
        [SerializeField] protected Transform parentBullet;

        public IEnumerator Init()
        {
            int index = 0;
            while (index < maxBulletCount)
            {
                Bullet temp = Instantiate(bullet, parentBullet);
                temp.Reset();
                listBullet.Add(temp);
                index++;
                if (index % 5 == 0)
                {
                    yield return null;
                }
            }
        }

        public Bullet GetBullet()
        {
            if (listBullet.Count <= 0)
            {
                StartCoroutine(Init());
            }
            Bullet temp = listBullet[0];
            listBullet.Remove(temp);
            temp.gameObject.SetActive(true);
            temp.transform.SetParent(null);
            return temp;
        }

        public void ReturnBullet(Bullet bullet)
        {
            bullet.transform.SetParent(parentBullet);
            bullet.Reset();
            listBullet.Add(bullet);
        }

    }
}
