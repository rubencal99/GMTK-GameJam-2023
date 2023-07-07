using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Script requires RigidBody attached to Player object
[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    // MovementData is a scriptable object that contains data regarding movement
    [field: SerializeField]
    public MovementData MovementData { get; set; }

    // This is only serialized for debugging purposes
    [SerializeField]
    public float currentVelocity = 0;
    [SerializeField]
    public Vector3 movementDirection;



    public Rigidbody2D rigidbody;

    // This passes currentVelocity to AgentAnimations.AnimatePlayer in Editor
    [field: SerializeField]
    public UnityEvent<float> OnVelocityChange { get; set; }

    protected void Awake()
    {
        // Grabs RigidBody that the script is attached to
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Takes Vector2 from AgentInput OnMovementKeyPressed
    public virtual void MoveAgent(Vector2 movementInput)
    {
        // rigidbody2D.velocity = movementInput.normalized * currentVelocity;
        if (movementInput.magnitude > 0)
        {
            movementDirection = movementInput.normalized;
        }
        else
        {
            //movementDirection = Vector2.zero;
        }

        currentVelocity = calculateSpeed(movementInput);

        // This invokes animations
        /*
        if (this.GetComponentInChildren<AgentAnimations>() != null)
            this.GetComponentInChildren<AgentAnimations>().SetWalkAnimation(movementInput.magnitude > 0);
        */
    }

    // this function integrates acceleration
    protected virtual float calculateSpeed(Vector3 movementInput)
    {
        if (movementInput.magnitude > 0)
        {
            currentVelocity += MovementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentVelocity -= MovementData.decceleration * Time.deltaTime;
        }
        // Returns velocity between 0 and maxSpeed
        return Mathf.Clamp(currentVelocity, 0, MovementData.maxRunSpeed);
    }

    protected virtual void FixedUpdate()
    {
        OnVelocityChange?.Invoke(currentVelocity);
        if (rigidbody != null)
        {
            rigidbody.velocity = currentVelocity * movementDirection.normalized;
            //rigidbody.velocity = Vector3.Scale(rigidbody.velocity, new Vector3(1f, 1f, 1.3f));
        }
    }
}