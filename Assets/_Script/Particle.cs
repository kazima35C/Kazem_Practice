using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Particle : MonoBehaviour
    {
        private readonly float lifeTime = 2;
        [SerializeField] private Renderer particleRenderer;
        [SerializeField] private ParticleSystem particle;

        public void Init(Vector3 position, Quaternion quaternion, Material material)
        {
            transform.SetPositionAndRotation(position, quaternion);
            particleRenderer.material = material;
            gameObject.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(LifeEffect());
        }

        private void Start()
        {
            if (TimeManager.Instance.IsPause.Value)
            {
                particle.Pause();
            }
            TimeManager.Instance.IsPause.OnChange += () =>
            {
                if (TimeManager.Instance.IsPause.Value)
                {
                    particle.Pause();

                    return;
                }
                particle.Play();
            };
        }


        public IEnumerator LifeEffect()
        {
            yield return new WaitForGameSeconds(lifeTime);
            EffectPool.Instance.ReturnParticle(this);
        }


        public void Reset()
        {
            gameObject.SetActive(false);
        }
    }
}
