using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDecision : AIDecision
{
    public float time = 1.5f;
    public float Timer = 1.5f;
    public bool timerStart = false;
    public override bool MakeADecision()
    {
        timerStart = true;
        if(Timer < 0)
        {
            timerStart = false;
            Timer = time;
            return true;
        }
        return false;
    }

    private void Update()
    {
        if(timerStart)
        {
            Timer -= Time.deltaTime;
        }
    }
}
