using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class EffectPool : Singleton<EffectPool>
    {
        [SerializeField] protected Particle particle;
        [SerializeField] protected List<Particle> listParticle;
        [SerializeField] protected int maxParticleCount = 20;
        [SerializeField] protected Transform parentParticle;

        public IEnumerator Init()
        {
            int index = 0;
            while (index < maxParticleCount)
            {
                Particle temp = Instantiate(particle, parentParticle);
                temp.gameObject.SetActive(false);
                listParticle.Add(temp);
                temp.Reset();
                index++;
                if (index % 5 == 0)
                {
                    yield return null;
                }
            }
        }

        public Particle GetParticle()
        {
            if (listParticle.Count <= 0)
            {
                StartCoroutine(Init());
            }

            Particle temp = listParticle[0];
            listParticle.Remove(temp);
            temp.transform.SetParent(null);
            return temp;
        }

        public void ReturnParticle(Particle particle)
        {
            particle.transform.SetParent(parentParticle);
            particle.Reset();
            listParticle.Add(particle);
        }

    }
}
