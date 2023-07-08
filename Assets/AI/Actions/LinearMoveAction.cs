using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMoveAction : AIAction
{
    public override void TakeAction()
    {
        var direction = (Vector3)aiMovementData.PointOfInterest - transform.position;
        aiMovementData.Direction = direction.normalized;
        agentBrain.Move(aiMovementData.Direction);
    }
}
