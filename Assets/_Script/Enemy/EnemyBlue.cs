using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
  public class EnemyBlue : Enemy
  {
    public override void UpdateEnemy()
    {
      if (health.IsDead)
      {
        Die();
      }
      transform.position = Vector3.MoveTowards(transform.position, Player.Instance.transform.position, speed * Time.deltaTime);
      transform.LookAt(Player.Instance.transform.position);
    }

  }
}
