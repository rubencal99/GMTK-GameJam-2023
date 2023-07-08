using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Composite")]
public class CompositeBehavior : FlockBehavior
{

    [System.Serializable]
    public class BehaviorWeight
    {
        public FlockBehavior behavior;
        public float weight;
    }


    public List<BehaviorWeight> behaviorWeights = new List<BehaviorWeight>();
    /*public FlockBehavior[] behaviors;
    public float[] weights;*/

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        /*if(weights.Length != behaviors.Length)
        {
            Debug.LogError("Data mismatch in " + name, this);
            return Vector2.zero;
        }*/

        // set up move
        Vector2 move = Vector2.zero;

        // iterate through behaviors
        foreach(BehaviorWeight behaviorWeight in behaviorWeights)
        {
            FlockBehavior behavior = behaviorWeight.behavior;
            float weight = behaviorWeight.weight;

            Vector2 partialMove = behavior.CalculateMove(agent, context, flock) * weight;

            if(partialMove != Vector2.zero)
            {
                if(partialMove.sqrMagnitude > weight * weight)
                {
                    partialMove.Normalize();
                    partialMove *= weight;
                }
                move += partialMove;
            }
        }


        /*for(int i = 0; i < behaviors.Length; i++)
        {
            Vector2 partialMove = behaviors[i].CalculateMove(agent, context, flock) * weights[i];

            if(partialMove != Vector2.zero)
            {
                if(partialMove.sqrMagnitude > weights[i] * weights[i])
                {
                    partialMove.Normalize();
                    partialMove *= weights[i];
                }
                move += partialMove;
            }
        }*/

        return move;

    }
}
