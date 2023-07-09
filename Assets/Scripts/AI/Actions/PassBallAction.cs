using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassBallAction : AIAction
{
    public override void TakeAction()
    {
        agentBrain.Shoot();
    }
}
