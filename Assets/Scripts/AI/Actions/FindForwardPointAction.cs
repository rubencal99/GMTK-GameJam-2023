using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindForwardPointAction : AIAction
{
    [SerializeField]
    float distanceToPoint = 1f;
    [SerializeField]
    float randomBias;

    float Timer = 1.5f;
    float time = 1.5f;
    public override void TakeAction()
    {
        aiMovementData.PointOfInterest = FindForwardPoint();
    }

    Vector2 FindForwardPoint()
    {
        /*if(Timer < 0 && Random.Range(0, 100) < 30)
        {
            agentBrain.Shoot();
        }*/
        if (Vector2.Distance(transform.position, aiMovementData.PointOfInterest) > distanceToPoint &&
            Timer > 0)
            return aiMovementData.PointOfInterest;

        Vector2 goal = aiMovementData.PointOfInterest;
        Vector2 currentPos = transform.position;
        Vector2 closePoint = (goal + currentPos) * 0.25f;
        Vector2 finalPoint = closePoint + new Vector2(Random.Range(-randomBias, randomBias), Random.Range(-randomBias, randomBias));

        ResetTimer();
        return finalPoint;
    }

    void OnDrawGizmos()
    {
        if (!Application.isPlaying)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(aiMovementData.PointOfInterest, 0.5f);
    }

    private void Update()
    {
        Timer -= Time.deltaTime;
    }

    void ResetTimer()
    {
        Timer = time;
    }
}
