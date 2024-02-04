using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class TimeManager : Singleton<TimeManager>
    {
        public Observable<bool> IsPause = new();
        private bool isPause = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPause = !isPause;
                IsPause.Value =isPause;
            }
        }

    }
}
