using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RefereeInput : MonoBehaviour
{
    // The Vector2 corresponds to the magnitude of movement in the (x, y)    wasd
    // (0, 0), (0, 1), (1, 0), (1, 1), (0, -1), (-1, 0), (-1, -1), (1, -1), (-1, 1)
    // Passes the Vector2 to AgentMovement.MoveAgent hence SerializeField
    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }

    // Vector2 coresponds to the position of the mouse on the screen
    // This funciton is used to aim the weapon and change player direction
    [field: SerializeField]
    public UnityEvent<Vector2> OnPointerPositionChange { get; set; }

    // Calls PlayerWeapon.shoot
    [field: SerializeField]
    public UnityEvent OnPrimaryButtonPressed { get; set; }

    // Calls PlayerWeapon.StopShooting
    [field: SerializeField]
    public UnityEvent OnPrimaryButtonReleased { get; set; }

    [field: SerializeField]
    public UnityEvent OnInteractKeyPressed { get; set; }

    [field: SerializeField]
    public UnityEvent OnTabKeyPressed { get; set; }

    [field: SerializeField]
    public UnityEvent OnEscKeyPressed { get; set; }
}