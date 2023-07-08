using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindGoalAction : AIAction
{
    [SerializeField]
    float randomBias;
    public override void TakeAction()
    {
        //agentBrain.FindGoals();
        aiMovementData.PointOfInterest = agentBrain.closestEnemyGoal.transform.position;
        aiMovementData.PointOfInterest += new Vector2(Random.Range(-randomBias, randomBias), Random.Range(-randomBias, randomBias));
    }
}
