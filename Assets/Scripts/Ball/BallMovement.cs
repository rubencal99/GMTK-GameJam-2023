using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // MovementData is a scriptable object that contains data regarding movement
    [field: SerializeField]
    public BallData BallData { get; set; }

    // This is only serialized for debugging purposes
    [SerializeField]
    public float currentVelocity = 0;
    [SerializeField]
    public Vector3 movementDirection;

    // Update is called once per frame
    void Update()
    {
        //calculateSpeed();
    }

    // this function integrates acceleration
    /*protected virtual float calculateSpeed()
    {
        //currentVelocity -= MovementData.decceleration * Time.deltaTime;
        // Returns velocity between 0 and maxSpeed
        //return Mathf.Clamp(currentVelocity, 0, MovementData.maxRunSpeed);
    }*/
}
