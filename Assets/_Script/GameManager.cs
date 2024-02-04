using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameManager : Singleton<GameManager>
    {
        public string GameTime
        {
            get
            {
                float currentTime = Time.time;
                int minutes = Mathf.FloorToInt(currentTime / 60);
                int seconds = Mathf.FloorToInt(currentTime % 60);
                string formattedTime = string.Format("{0}:{1}", minutes, seconds);
                return formattedTime;
            }
        }
        public int HealthPlayer => Player.Instance.playerHP.CurrentHealth>=0?Player.Instance.playerHP.CurrentHealth:0;
        
        public Observable<int> enemyKilled = new();
    }

}
