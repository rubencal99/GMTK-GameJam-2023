using System.Collections;
using UnityEngine;

public class FoulTracker : MonoBehaviour
{
    public static FoulTracker instance;
    private bool recentFoul = false;
    private Foul currentFoul;
    private IEnumerator currentCoroutine;
    private bool whistleBlown = false;

    private void Awake()
    {
        instance = this;
    }

    public void StopCountdown()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
            currentCoroutine = null;
        }
    }

    public void FoulHappened(Foul foul)
    {
        if (currentCoroutine == null)
        {
            currentFoul = foul;
            recentFoul = true;
            currentCoroutine = WaitForFlag();

            StartCoroutine(currentCoroutine);
        }
        else if (recentFoul == true)
        {
            //Anger meter goes up for missing the previous foul

            currentFoul = foul;
            recentFoul = true;

            StopCoroutine(currentCoroutine);
            currentCoroutine = WaitForFlag();
            StartCoroutine(currentCoroutine);
        }
    }

    private IEnumerator WaitForFlag()
    {
        float timeElapsed = 0f;
        float timeDuration = 5f;

        while (timeElapsed < timeDuration)
        {
            //if player calls foul, end
            //else add to timeElapsed
            timeElapsed += Time.deltaTime;

            yield return null;
            //*****
            //In reality can just stop the coroutine when the whistle is blown. Will either end with
            //A positive or negative audinece reception. No need to resume the timer.
        }

        currentCoroutine = null;
        print("Missed foul! Type: " + currentFoul.foulType);
    }
}

public struct Foul
{
    public enum FoulType { BALLOOB, PLAYEROOB, OFFSIDES, GOAL};
    public FoulType foulType;
    public int team;

    public Foul(FoulType _foulType, int _team)
    {
        foulType = _foulType;
        team = _team;
    }
}
