using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBallAction : AIAction
{
    public override void TakeAction()
    {
        agentBrain.ballController.ShootBall();
    }
}
