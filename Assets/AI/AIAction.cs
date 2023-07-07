using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dictates what should happen when we enter a state
public abstract class AIAction : MonoBehaviour
{
    protected AgentBrain agentBrain;
    private void Awake()
    {
        //aiActionData = transform.parent.parent.GetComponentInChildren<AIActionData>();
        //aiMovementData = transform.parent.parent.GetComponentInChildren<AIMovementData>();
        agentBrain = transform.parent.parent.GetComponent<AgentBrain>();
    }

    public abstract void TakeAction();
}
