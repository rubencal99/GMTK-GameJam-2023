using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Responsible for range booleans
public class AIActionData : MonoBehaviour
{
    [field: SerializeField]
    public bool Attack { get; set; }

    [field: SerializeField]
    [Range(1f, 100)]
    public float Range = 10;
}
