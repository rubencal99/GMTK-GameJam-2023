using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    private AgentBrain agentBrain = null;

    [SerializeField]
    private List<AIAction> Actions = null;
    // Transitions should be ordered based on priority
    [SerializeField]
    private List<AITransition> Transitions = null;

    private void Awake()
    {
        agentBrain = transform.parent.parent.GetComponent<AgentBrain>();
        //Actions.Clear();
        //Actions = new List<AIAction>(GetComponents<AIAction>());
        Transitions.Clear();
        Transitions = new List<AITransition>(GetComponentsInChildren<AITransition>());
    }

    // This will be called in enemy brain script
    // Depending on state, there'll be different actions/transitions
    public void UpdateState()
    {
        foreach (var action in Actions)
        {
            action.TakeAction();
        }
        foreach (var transition in Transitions)
        {
            // player in range == false -> Back to idle
            // player visible == true -> Chase
            bool result = false;
            foreach (var decision in transition.Decisions)
            {
                result = decision.MakeADecision();
                if (result == false)
                {
                    break;
                }
            }
            if (result)
            {
                if (transition.PositiveResult != null)
                {
                    Debug.Log("Transitioning to " + transition.PositiveResult);
                    agentBrain.ChangetoState(transition.PositiveResult);
                    return;
                }
            }
            else
            {
                if (transition.NegativeResult != null)
                {
                    agentBrain.ChangetoState(transition.NegativeResult);
                    return;
                }
            }
        }
    }
}
