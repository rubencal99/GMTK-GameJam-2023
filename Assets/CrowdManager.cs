using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrowdManager : MonoBehaviour
{
    public static CrowdManager instance;
    private int currentAnger = 0;
    private int maxAnger = 100;
    [SerializeField]
    private Sprite[] faces = new Sprite[6];
    [SerializeField]
    private Image moodGuage;
    private Sounds sounds;

    private void Awake()
    {
        instance = this;
        moodGuage.sprite = faces[0];
        sounds = GetComponent<Sounds>();
        sounds.PlaySoundLoop(4);
    }

    //This should contain all the values for how much anger increases/decreases.
    public Dictionary<string, int> crowdPeeves = new Dictionary<string, int>()
    {
        {"NoCall_Foul", 10 },           //FoulManager
        {"Call_NoFoul", 10 },           //
        {"WrongFoul_RightTeam", 15 },
        {"RightFoul_WrongTeam", 20},
        {"WrongFoul_WrongTeam", 25},
        {"BallContact", 15},
        {"RefScores", 50 }
    };

    public void BadCall(string badCallType)
    {
        sounds.PlaySound(1);
        currentAnger += crowdPeeves[badCallType];
        print("Anger level: " + currentAnger);
        ChangeFace();
        CheckDefeat();
        StageManager.instance.AnnounceCall();
    }

    public void GoodCall()
    {
        sounds.PlaySound(5);
        currentAnger -= 10;
        Mathf.Clamp(currentAnger, 0, 100);
        print("Anger level: " + currentAnger);
        ChangeFace();
    }

    public void ChangeFace()
    {
        //My magnum opus
        if (currentAnger <= 20)
        {
            moodGuage.sprite = faces[0];
        }
        else if (currentAnger <= 40)
        {
            moodGuage.sprite = faces[1];
        }
        else if (currentAnger <= 60)
        {
            moodGuage.sprite = faces[2];
        }
        else if (currentAnger <= 80)
        {
            moodGuage.sprite = faces[3];
        }
        else if (currentAnger <= 100)
        {
            moodGuage.sprite = faces[4];
        }
        else if (currentAnger > 100)
        {
            moodGuage.sprite = faces[5];
        }
    }

    public void CheckDefeat()
    {
        if (currentAnger > maxAnger)
        {
            StageManager.instance.Defeat();
        }
    }

    //Slow decrease in anger over time, if > 0
}
