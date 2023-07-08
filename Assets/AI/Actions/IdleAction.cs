using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : AIAction
{
    public override void TakeAction()
    {
        aiMovementData.Direction = Vector3.zero;
        // aiMovementData.PointOfInterest = transform.position;
        agentBrain.Move(aiMovementData.Direction);
    }
}
