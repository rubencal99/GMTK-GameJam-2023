using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceEnemyPlayerDecision : AIDecision
{
    [field: SerializeField]
    [field: Range(0.1f, 20)]
    public float Distance { get; set; } = 5;

    public override bool MakeADecision()
    {
        //Debug.Log(agentBrain);
        agentBrain.FindEnemy();
        var d = Vector2.Distance(agentBrain.closestEnemy.transform.position, transform.position);

        if (d < Distance)
        {
            return true;
        }
        return false;
    }

    protected void OnDrawGizmos()
    {
        if (!Application.isPlaying)
            return;
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, Distance);
        Gizmos.DrawSphere(agentBrain.closestEnemy.transform.position, 0.5f);
        Gizmos.color = Color.white;
    }
}
