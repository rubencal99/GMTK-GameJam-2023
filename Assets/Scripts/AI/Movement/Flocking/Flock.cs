using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{ 
    public FlockAgent NormalAgent;
    public FlockAgent BigAgent;
    public FlockAgent PariahAgent;
    protected List<FlockAgent> agents = new List<FlockAgent>();
    //public FlockBehavior behavior;

    [Range(10, 500)]
    public int startingCount = 250;

    [Range(-1, 10)]
    public int bigDensity = 0;

    protected const float AgentDensity = 0.08f;

    /*[Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(0.1f, 30f)]
    public float neighborRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius{ get {return squareAvoidanceRadius;}}
*/
    // Start is called before the first frame update
    protected virtual void Start()
    {
        //squareMaxSpeed = maxSpeed * maxSpeed;
        //squareNeighborRadius = neighborRadius * neighborRadius;
        //squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for(int i = 0; i < startingCount; i++)
        {
            int r = Random.Range(0, 100);
            FlockAgent newAgent = r > bigDensity ? 
                Instantiate(
                NormalAgent,
                Random.insideUnitCircle * startingCount * AgentDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
            ) : 
            Instantiate(
                BigAgent,
                Random.insideUnitCircle * startingCount * AgentDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
            );
            newAgent.transform.GetComponentInChildren<SpriteRenderer>().color = new Color(Random.Range(50,255f)/255f, Random.Range(50,255f)/255f, Random.Range(50,255f)/255f);
            newAgent.name += i;
            agents.Add(newAgent);
        }

    }

    // Update is called once per frame
    protected void Update()
    {
        foreach(FlockAgent agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);

            // For demo only
            //agent.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, context.Count / 6f);

            Vector2 move = agent.behavior.CalculateMove(agent, context, this);
            move *= agent.driveFactor;
            if(move.sqrMagnitude > agent.SquareMaxSpeed)
            {
                move = move.normalized * agent.maxSpeed;
            }
            agent.Move(move);
        }
    }

    protected List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(agent.transform.position, agent.neighborRadius, agent.layerMask);
        foreach(Collider2D c in colliders)
        {
            if(c!= agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }
        agent.neighbors = context;
        return context;
    }
}
