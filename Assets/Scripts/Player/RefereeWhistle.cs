using UnityEngine;

public class RefereeWhistle : MonoBehaviour
{
    private AgentInput agentInput;
    private AgentMovement agentMovement;
    public GameObject flagPanel;

    private void Awake()
    {
        agentInput = GetComponent<AgentInput>();
        agentMovement = GetComponent<AgentMovement>();
    }

    public void Whistle()
    {
        //Players on field stop moving
        agentInput.enabled = false;
        agentMovement.currentVelocity = 0;
        //User can no longer move
        //Open flag UI - DONE
        //Play whistle blowing sound, animation
        //Pause countdown timer - DONE
        //(if active) Pause WaitForFlag coroutine in FoulTracker - DONE
        StageManager.instance.WhistleBlown();
    }
        
}
