using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushBallAction : AIAction
{
    [field: SerializeField]
    [field: Range(0.1f, 20)]
    public float Distance { get; set; } = 0.5f;
    public override void TakeAction()
    {
        aiMovementData.PointOfInterest = agentBrain.closestBall.transform.position;
        var direction = (Vector3)aiMovementData.PointOfInterest - transform.position;
        aiMovementData.Direction = direction.normalized;

        var d = Vector3.Distance(agentBrain.closestBall.transform.position, transform.position);
        if (d > Distance)
            agentBrain.Move(aiMovementData.Direction);
    }
}
