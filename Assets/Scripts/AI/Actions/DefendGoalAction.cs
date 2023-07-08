using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendGoalAction : AIAction
{
    public int distanceFromGoal;
    Vector2 defensePos;
    public override void TakeAction()
    {
        aiMovementData.PointOfInterest = FindPoint();
    }

    public Vector2 FindPoint()
    {
        agentBrain.FindBall();
        Vector2 ballPos = agentBrain.closestBall.transform.position;
        agentBrain.FindGoal();
        Vector2 goalPos = agentBrain.closestGoal.transform.position;

        var direction = (ballPos - goalPos).normalized;

        Debug.DrawRay(goalPos, direction);

        defensePos = goalPos + (direction * distanceFromGoal);

        return defensePos;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(defensePos, 0.5f);
    }
}
