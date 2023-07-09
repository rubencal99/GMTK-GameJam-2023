using UnityEngine;

public class RefereeWhistle : MonoBehaviour
{
    private AgentInput agentInput;
    private AgentMovement agentMovement;
    private Sounds refSounds;
    public GameObject flagPanel;

    private void Awake()
    {
        agentInput = GetComponent<AgentInput>();
        agentMovement = GetComponent<AgentMovement>();
        refSounds = GetComponent<Sounds>();
    }

    public void Whistle()
    {
        //Players on field stop moving
        //User can no longer move - DONE
        agentInput.enabled = false;
        agentMovement.currentVelocity = 0;
        //Open flag UI - DONE
        //Play whistle blowing sound, animation
        refSounds.PlaySound(0);
        //Pause countdown timer - DONE
        //(if active) Pause WaitForFlag coroutine in FoulTracker - DONE
        StageManager.instance.WhistleBlown();
    }
    
    public void EnableInput()
    {
        agentInput.enabled = false;
    }
}
