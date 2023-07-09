using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindRandomTeammateAction : AIAction
{
    public override void TakeAction()
    {
        aiMovementData.PointOfInterest = FindTeammate();
    }

    public Vector2 FindTeammate()
    {
        return agentBrain.teammates[Random.Range(0, agentBrain.teammates.Count)].transform.position;
    }
}
