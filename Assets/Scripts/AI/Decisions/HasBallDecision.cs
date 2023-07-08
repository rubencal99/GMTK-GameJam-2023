using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasBallDecision : AIDecision
{
    public override bool MakeADecision()
    {
        return agentBrain.ballController.hasBall;
    }
}
