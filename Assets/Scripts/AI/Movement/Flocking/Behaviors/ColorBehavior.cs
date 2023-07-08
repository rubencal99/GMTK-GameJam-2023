using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Color")]
public class ColorBehavior : FlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // if no neighbors, return no adjustment
        if (context.Count == 0)
        {
            return Vector2.zero;
        }

        /*Color newColor = agent.spriteRenderer.color;
        foreach (Transform item in context)
        {
            newColor += item.GetComponent<FlockAgent>().spriteRenderer.color;
        }
        newColor /= context.Count;*/
        Color newColor = context[Random.Range(0, context.Count)].GetComponent<FlockAgent>().spriteRenderer.color;

        if(Random.Range(0,100) < 50)
        {
            agent.spriteRenderer.color = newColor;
        }

        return Vector2.zero;
    }
}
