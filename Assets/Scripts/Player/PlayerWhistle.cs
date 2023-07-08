using UnityEngine;

public class PlayerWhistle : MonoBehaviour
{
    public GameObject flagPanel;

    public void Whistle()
    {
        //Players on field stop moving
        //User can no longer move
        //Open flag UI
        //Play whistle blowing sound, animation
        //Pause countdown timer - DONE
        //(if active) Pause WaitForFlag coroutine in FoulTracker - DONE
        print("FWEEEEEET");
        StageManager.instance.WhistleBlown();
    }
        
}
