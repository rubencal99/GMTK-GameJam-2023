using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendGoalAction : AIAction
{
    public int distanceFromGoal;
    public Vector2 defensePos;
    public Vector2 randomBias;
    public override void TakeAction()
    {
        aiMovementData.PointOfInterest = FindPoint();
    }

    public Vector2 FindPoint()
    {
        if(randomBias == null)
            randomBias = new Vector2(Random.Range(0f, 2f), Random.Range(0f, 2f));

        agentBrain.FindBall();
        Vector2 ballPos = agentBrain.closestBall.transform.position;
        //agentBrain.FindGoals();
        Vector2 goalPos = agentBrain.closestGoal.transform.position;

        var direction = (ballPos - goalPos).normalized;

        Debug.DrawRay(goalPos, direction);

        defensePos = goalPos + (direction * distanceFromGoal);

        defensePos += randomBias;

        return defensePos;
    }

    void OnDrawGizmos()
    {
        if (!Application.isPlaying)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(defensePos, 0.5f);
    }
}
