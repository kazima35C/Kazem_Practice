using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

    public class Player : Singleton<Player>
    {
        public Health playerHP;
        [SerializeField] private PlayerRotate playerRotate;
        [SerializeField] private List<PlayerWeapon> playerWeapons;

        private void Update()
        {
            if (TimeManager.Instance.IsPause.Value) { return; }
            if (playerHP.IsDead) { return; }
            playerRotate.UpdateRotate();
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {
                playerWeapons[0].Shoot(transform.rotation);
                return;
            }
            if (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1))
            {
                playerWeapons[1].Shoot(transform.rotation);
            }
        }



    }
}
