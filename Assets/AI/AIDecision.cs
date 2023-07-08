using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    protected AIActionData aiActionData;
    protected AIMovementData aiMovementData;
    protected AgentBrain agentBrain;
    private void Awake()
    {
        aiActionData = transform.parent.parent.GetComponentInChildren<AIActionData>();
        aiMovementData = transform.parent.parent.GetComponentInChildren<AIMovementData>();
        agentBrain = transform.parent.parent.parent.GetComponent<AgentBrain>();
    }
    public abstract bool MakeADecision();
}

