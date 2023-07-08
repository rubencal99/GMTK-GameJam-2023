using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allows players to take posession of ball and maneuver it
public class BallController : MonoBehaviour
{
    public bool hasBall = false;

    public Vector2 aimDirection;
    public Quaternion rotation;
    //public Quaternion startingRotation;
    public float desiredAngle;

    public GameObject ballCollider;
    public Ball Ball;

    public void AimBall(Vector2 movementDirection)
    {
        //if (!hasBall)
            //return;

        //aimDirection = (movementDirection - (Vector2)transform.position).normalized;
        if(movementDirection != Vector2.zero)
            aimDirection = movementDirection;

        // Use arctan to find angle from our x-axis and convert to degrees
        desiredAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        // Calculates rotation between angle A and angle B
        //Debug.Log("Axis of Rotation: " + Vector3.up);
        rotation = Quaternion.AngleAxis(desiredAngle, Vector3.up);
        rotation.z = rotation.y;
        rotation.y = 0;
        //rotation.x = startingRotation.x;

        transform.localRotation = rotation;
    }

    public void ShootBall()
    {
        if (!hasBall)
            return;

        hasBall = false;

        Ball.transform.parent = null;
        Ball.inPossession = false;
        Ball.transform.rotation = Quaternion.identity;
        Ball.GetComponent<Rigidbody2D>().simulated = true;
        Ball.GetComponent<Rigidbody2D>().AddForce(80 * aimDirection);

        transform.localRotation = Quaternion.identity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            TryCaptureBall(collision);
        }
    }

    void TryCaptureBall(Collider2D collision)
    {
        Debug.Log("Attempting ball capture");
        ballCollider = collision.gameObject;
        Ball = ballCollider.GetComponent<Ball>();
        if(Ball == null)
            Ball = ballCollider.transform.parent.GetComponentInChildren<Ball>();

        if (!Ball.AttemptCapture())
            return;

        ResetPossesser();

        Ball.transform.rotation = Quaternion.identity;

        AimBall(collision.transform.position - transform.position);

        Ball.transform.parent = transform;
        Ball.GetComponent<Rigidbody2D>().simulated = false;
    }

    void ResetPossesser()
    {
        if(Ball.possesser)
        {
            Ball.possesser.hasBall = false;
            Ball.possesser.Ball = null;
            Ball.possesser.ballCollider = null;
        }
            
        hasBall = true;
        Ball.inPossession = true;
        Ball.possesser = this;
    }
}
