using System.Collections;
using UnityEngine;

public class FoulTracker : MonoBehaviour
{
    public static FoulTracker instance;
    private bool recentFoul = false;
    private Foul currentFoul;
    private IEnumerator currentCoroutine;

    private void Awake()
    {
        instance = this;
    }

    public void FoulHappened(Foul foul)
    {
        if (currentCoroutine == null)
        {
            currentFoul = foul;
            recentFoul = true;
            currentCoroutine = WaitForCall();

            StartCoroutine(currentCoroutine);
        }
        else if (recentFoul == true)
        {
            //Anger meter goes up for missing foul

            currentFoul = foul;
            recentFoul = true;

            StopCoroutine(currentCoroutine);
            currentCoroutine = WaitForCall();
            StartCoroutine(currentCoroutine);
        }
    }

    private IEnumerator WaitForCall()
    {
        float timeElapsed = 0f;
        float timeDuration = 5f;

        while (timeElapsed < timeDuration)
        {
            //if player blows whistle, pause
            //if player calls foul, end
            //else add to timeElapsed
            yield return null;
        }

        currentCoroutine = null;
        print("Missed foul!");
    }
}

public struct Foul
{
    enum FoulType { BALLOOB, PLAYEROOB, OFFSIDES, GOAL};
    FoulType foulType;
    bool team;
}
