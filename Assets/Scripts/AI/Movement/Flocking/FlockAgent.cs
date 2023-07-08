using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    Collider2D agentCollider;
    public Collider2D AgentCollider{ get {return agentCollider;}}

    public FlockBehavior behavior;
    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(0.1f, 30f)]
    public float neighborRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;
    [Range(1f, 20f)]
    public float flockWeight = 1f;

    public LayerMask layerMask;

    float squareMaxSpeed;
    public float SquareMaxSpeed{ get {return squareMaxSpeed;}}
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius{ get {return squareAvoidanceRadius;}}

    public List<Transform> neighbors;

    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<Collider2D>();

        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;
    }

    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
