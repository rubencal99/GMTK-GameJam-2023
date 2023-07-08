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
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        currentCoroutine = null;
        print("Missed foul! Type: " + currentFoul.foulType + ". Team: " + currentFoul.team.name);
    }
}

public struct Foul
{
    public enum FoulType { BALLOOB, PLAYEROOB, OFFSIDES, GOAL};
    public FoulType foulType;
    public Team team;

    public Foul(FoulType _foulType, Team _team)
    {
        foulType = _foulType;
        team = _team;
    }
}
