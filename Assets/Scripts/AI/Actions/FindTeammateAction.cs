using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class FindTeammateAction : AIAction
{
    public override void TakeAction()
    {
        aiMovementData.PointOfInterest = FindTeammate();
    }

    public Vector2 FindTeammate()
    {
        agentBrain.FindTeammate();
        return agentBrain.closestTeammate.transform.position;
    }

    protected void OnDrawGizmos()
    {
        if (agentBrain == null)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(agentBrain.closestTeammate.transform.position, 0.5f);
        Gizmos.color = Color.white;
    }
}
