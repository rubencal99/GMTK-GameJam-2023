using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class AgentBrain : MonoBehaviour
{
    [field: SerializeField]
    public AIState CurrentState { get; set; }

    public GameObject closestBall;
    public GameObject closestGoal;
    public GameObject closestEnemyGoal;
    public GameObject closestEnemy;
    public GameObject closestTeammate;

    public Player player;
    public BallController ballController;

    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
    [field: SerializeField]
    public UnityEvent OnShootKeyPressed { get; set; }

    private void Start()
    {
        FindBall();
        FindGoals();
        FindEnemy();
        FindTeammate();
    }

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

    public void FindGoals()
    {
        foreach (Goal_Player goal in FindObjectsOfType<Goal_Player>())
        {
            Debug.Log("Player color: " + player.teamColor);
            Debug.Log("Goal color: " + goal.teamColor);
            if (goal.teamColor == player.teamColor)
            {
                closestGoal = goal.gameObject;
            }
            else
            {
                closestEnemyGoal = goal.gameObject;
            }
        }
    }

    public void FindEnemy()
    {
       // GameObject closestEnemyPlayer = null;
        var distance = 999.9f;
        foreach (Player p in FindObjectsOfType<Player>())
        {
            if(p.teamColor != player.teamColor)
            {
                var d = Vector2.Distance(transform.position, p.transform.position);
                if(d < distance)
                {
                    closestEnemy = p.gameObject;
                    distance = d;
                }
            }
        }
    }

    public void FindTeammate()
    {
        var distance = 999.9f;
        foreach (Player p in FindObjectsOfType<Player>())
        {
            if (p.teamColor == player.teamColor && p != player)
            {
                var d = Vector2.Distance(transform.position, p.transform.position);
                if (d < distance)
                {
                    closestTeammate = p.gameObject;
                    distance = d;
                }
            }
        }
    }
}
