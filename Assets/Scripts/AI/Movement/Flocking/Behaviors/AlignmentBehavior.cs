using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
public class AlignmentBehavior : FlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // if no neighbors, maintain current alignment
        if (context.Count == 0)
        {
            return agent.transform.up;
        }

        // Add all points together and average
        Vector2 alignmentMove = Vector2.zero;
        foreach (Transform item in context)
        {
            if(item.gameObject.layer == LayerMask.NameToLayer("Pariah"))
            {
                continue;
            }
            alignmentMove += (Vector2)item.transform.up * item.GetComponent<FlockAgent>().flockWeight;
        }

        alignmentMove /= context.Count;
        return alignmentMove;
    }
}
