using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allows players to take posession of ball and maneuver it
public class BallController : MonoBehaviour
{
    public bool hasBall = false;

    public float randomBias;
    public Vector2 aimDirection;
    public Quaternion rotation;
    //public Quaternion startingRotation;
    public float desiredAngle;

    public GameObject ballCollider;
    public Ball Ball;

    private void Update()
    {
        if (Ball == null)
            hasBall = false;
    }

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

        Ball.GetComponent<Rigidbody2D>().AddForce(1000 * (aimDirection + new Vector2(Random.Range(-randomBias, randomBias), Random.Range(-randomBias, randomBias))));
        DiscardBall();

        transform.localRotation = Quaternion.identity;
    }

    void DiscardBall()
    {
        hasBall = false;
        Ball.transform.parent = null;
        Ball.inPossession = false;
        Ball.possesser = null;
        Ball.transform.rotation = Quaternion.identity;
        Ball.GetComponent<Rigidbody2D>().simulated = true;
        ballCollider = null;
        Ball = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ball") ||
            collision.gameObject.layer == LayerMask.NameToLayer("BallDetector"))
        {
            TryCaptureBall(collision);
        }
    }

    void TryCaptureBall(Collider2D collision)
    {
        Debug.Log("Attempting ball capture");
        ballCollider = collision.gameObject;
        if(ballCollider.layer == LayerMask.NameToLayer("Ball"))
        {
            Ball = ballCollider.GetComponent<Ball>();
        }
        else if(ballCollider.layer == LayerMask.NameToLayer("BallDetector"))
        {
            Ball = ballCollider.GetComponent<BallController>().Ball;
        }
            
        if (Ball == null)
        {
            Debug.Log("No ball to capture.");
            return;
        }

        Debug.Log(Ball);
        if (!Ball.AttemptCapture())
            return;

        ResetPossesser();
        CaptureBall(collision);

    }

    void CaptureBall(Collider2D collision)
    {
        hasBall = true;
        Ball.inPossession = true;
        Ball.possesser = this;
        Ball.transform.rotation = Quaternion.identity;
        AimBall(collision.transform.position - transform.position);

        Ball.transform.parent = transform;
        Ball.GetComponent<Rigidbody2D>().simulated = false;

        //Ball.SetOwner(GetComponentInParent<PlayerTeam>().GetTeam());

        TeamManager.instance.inPossession = transform.parent.GetComponent<Player>().teamColor;
        //Ball.EnsureCapture(this);
    }

    void ResetPossesser()
    {
        if(Ball.possesser)
        {
            Ball.possesser.DiscardBall();
        }
    }
}
