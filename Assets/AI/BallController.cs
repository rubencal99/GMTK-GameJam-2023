using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allows players to take posession of ball and maneuver it
public class BallController : MonoBehaviour
{
    public bool hasBall = false;

    public Vector2 aimDirection;
    public Quaternion rotation;
    public Quaternion startingRotation;
    public float desiredAngle;


    public void AimBall(Vector2 movementDirection)
    {
        if (!hasBall)
            return;

        //aimDirection = (movementDirection - (Vector2)transform.position).normalized;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            CaptureBall(collision);
        }
    }

    void CaptureBall(Collider2D collision)
    {
        hasBall = true;

        collision.transform.parent = transform;
    }
}
