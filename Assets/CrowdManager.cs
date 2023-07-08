using System.Collections;
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
    private Image currentFace;

    private void Awake()
    {
        instance = this;
        currentFace = transform.GetChild(0).GetComponent<Image>();
        currentFace.sprite = faces[0];
    }

    //This should contain all the values for how much anger increases/decreases.
    public Dictionary<string, int> crowdPeeves = new Dictionary<string, int>()
    {
        {"NoCall_Foul", 10 },
        {"Call_NoFoul", 10 },
        {"WrongFoul_RightTeam", 15 },
        {"RightFoul_WrongTeam", 20},
        {"WrongFoul_WrongTeam", 25},
        {"BallContact", 15},
        {"RefScores", 50 }
    };

    public void BadCall(string badCallType)
    {
        currentAnger += crowdPeeves[badCallType];
        print("Anger level: " + currentAnger);

        if(currentAnger <= 20)
        {
            currentFace.sprite = faces[0];
        }
        else if(currentAnger <= 40)
        {
            currentFace.sprite = faces[1];
        }
        else if(currentAnger <= 60)
        {
            currentFace.sprite = faces[2];
        }
        else if(currentAnger <= 80)
        {
            currentFace.sprite = faces[3];
        }
        else if(currentAnger <= 100)
        {
            currentFace.sprite = faces[4];
        }
        else if(currentAnger > 100)
        {
            currentFace.sprite = faces[5];
            //Game over!
        }
    }

    //Slow decrease in anger over time, if > 0
}
