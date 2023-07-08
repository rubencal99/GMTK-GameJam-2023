using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDecision : AIDecision
{
    [field: SerializeField]
    [field: Range(0.1f, 20)]
    public float Distance { get; set; } = 5;

    public override bool MakeADecision()
    {
        var d = Vector3.Distance(aiMovementData.PointOfInterest, transform.position);

        if (d < Distance)
        {
            return true;
        }
        return false;
    }

    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, Distance);
        Gizmos.color = Color.white;
    }
}
