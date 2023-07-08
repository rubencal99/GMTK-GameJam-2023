using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]
public class AvoidanceBehavior : FlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // if no neighbors, return no adjustment
        if (context.Count == 0)
        {
            return Vector2.zero;
        }

        // Add all points together and average
        Vector2 avoidanceMove = Vector2.zero;
        int avoidNum = 0;
        foreach (Transform item in context)
        {
            if(Vector2.SqrMagnitude(item.position - agent.transform.position) < agent.SquareAvoidanceRadius || 
                item.gameObject.layer == LayerMask.NameToLayer("Pariah"))
            {
                avoidNum++;
                avoidanceMove += (Vector2)(agent.transform.position - item.position) * item.GetComponent<FlockAgent>().flockWeight;
            }
        }

        if(avoidNum > 0)
        {
            avoidanceMove /= avoidNum;
        }
        return avoidanceMove;
    }
}
