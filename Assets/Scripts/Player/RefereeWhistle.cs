using UnityEngine;

public class RefereeWhistle : MonoBehaviour
{
    public GameObject flagPanel;

    public void Whistle()
    {
        //Players on field stop moving
        //User can no longer move
        //Open flag UI - DONE
        //Play whistle blowing sound, animation
        //Pause countdown timer - DONE
        //(if active) Pause WaitForFlag coroutine in FoulTracker - DONE
        StageManager.instance.WhistleBlown();
    }
        
}
