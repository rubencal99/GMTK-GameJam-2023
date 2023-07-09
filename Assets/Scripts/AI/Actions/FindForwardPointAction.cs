using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindForwardPointAction : AIAction
{
    [SerializeField]
    float distanceToPoint = 1f;
    [SerializeField]
    float randomBias;
    public override void TakeAction()
    {
        aiMovementData.PointOfInterest = FindForwardPoint();
    }

    Vector2 FindForwardPoint()
    {
        if (Vector2.Distance(transform.position, aiMovementData.PointOfInterest) > distanceToPoint)
            return aiMovementData.PointOfInterest;

        Vector2 goal = agentBrain.closestEnemyGoal.transform.position;
        Vector2 currentPos = transform.position;
        Vector2 closePoint = (goal + currentPos) * 0.25f;
        Vector2 finalPoint = closePoint + new Vector2(Random.Range(-randomBias, randomBias), Random.Range(-randomBias, randomBias));
        return finalPoint;
    }

    void OnDrawGizmos()
    {
        if (!Application.isPlaying)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(aiMovementData.PointOfInterest, 0.5f);
    }
}
