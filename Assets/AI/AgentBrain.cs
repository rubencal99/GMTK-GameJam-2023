using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class AgentBrain : MonoBehaviour
{
    [field: SerializeField]
    public AIState CurrentState { get; set; }


    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
    [field: SerializeField]
    public UnityEvent OnShootKeyPressed { get; set; }

    private void Update()
    {
        CurrentState.UpdateState();
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
}
