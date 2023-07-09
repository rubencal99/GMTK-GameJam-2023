using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : AgentMovement
{
    float squareMaxSpeed;
    public float SquareMaxSpeed { get { return squareMaxSpeed; } }
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(0.1f, 30f)]
    public float neighborRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;
    Collider2D agentCollider;
    public List<Transform> neighbors;
    public Collider2D AgentCollider { get { return agentCollider; } }

    public LayerMask layerMask;

    // Update is called once per frame
    protected void Update()
    {

        List<Transform> context = GetNearbyObjects();

        // For demo only
        //agent.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, context.Count / 6f);

        Vector2 move = CalculateMove(context);
        move *= driveFactor;
        if (move.sqrMagnitude > SquareMaxSpeed)
        {
            move = move.normalized * maxSpeed;
        }
        Move(move);
    }

    protected List<Transform> GetNearbyObjects()
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, neighborRadius, layerMask);
        foreach (Collider2D c in colliders)
        {
            if (c != AgentCollider)
            {
                context.Add(c.transform);
            }
        }
        neighbors = context;
        return context;
    }

    public  Vector2 CalculateMove(List<Transform> context)
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
            if (Vector2.SqrMagnitude(item.position - transform.position) < SquareAvoidanceRadius)
            {
                avoidNum++;
                avoidanceMove += (Vector2)(transform.position - item.position) * item.GetComponent<FlockAgent>().flockWeight;
            }
        }

        if (avoidNum > 0)
        {
            avoidanceMove /= avoidNum;
        }
        return avoidanceMove;
    }

    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }


}
