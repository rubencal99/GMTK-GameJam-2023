using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class AgentBrain : MonoBehaviour
{
    [field: SerializeField]
    public AIState CurrentState { get; set; }

    public GameObject closestBall;
    public GameObject closestGoal;


    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
    [field: SerializeField]
    public UnityEvent OnShootKeyPressed { get; set; }

    private void Update()
    {
        CurrentState.UpdateState();
        //FindBall();
    }

    internal void ChangetoState(AIState State)
    {
        CurrentState = State;
    }

    public void Move(Vector2 movementDirection)
    {
        //Debug.Log("Movement Direction: " + movementDirection);
        OnMovementKeyPressed?.Invoke(movementDirection);
    }
    public void Shoot()
    {
        OnShootKeyPressed?.Invoke();
    }

    public void FindBall()
    {
        foreach(Ball ball in FindObjectsOfType<Ball>())
        {
            if(closestBall == null)
            {
                closestBall = ball.gameObject;
            }
            if(Vector2.Distance(ball.transform.position, transform.position) < Vector2.Distance(closestBall.transform.position, transform.position)) 
            {
                closestBall = ball.gameObject;
            }
        }
    }

    public void FindGoal()
    {
        foreach (Goal_Player goal in FindObjectsOfType<Goal_Player>())
        {
            if (closestGoal == null)
            {
                closestGoal = goal.gameObject;
            }
            if (Vector2.Distance(goal.transform.position, transform.position) < Vector2.Distance(closestGoal.transform.position, transform.position))
            {
                closestGoal = goal.gameObject;
            }
        }
    }
}
