using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Game;
using UnityEngine;

public class WaitForGameSeconds : CustomYieldInstruction
{
    private float waitSeconds = 0;
    private float currentSeconds = 0;
    public WaitForGameSeconds(float _waitSeconds)
    {
        waitSeconds = _waitSeconds;
    }

    public override bool keepWaiting
    {
        get
        {
            if (TimeManager.Instance.IsPause.Value){
                return true;
            }
            if(currentSeconds < waitSeconds)
            {
                currentSeconds += Time.deltaTime;
                return true;
            }
            else
            {
                currentSeconds = 0;
                waitSeconds = 0;
                return false;
            }

        }
    }
}
