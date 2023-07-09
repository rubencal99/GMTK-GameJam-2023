using System.Collections;
using UnityEngine;

public class FoulManager : MonoBehaviour
{
    public static FoulManager instance;
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
            CrowdManager.instance.BadCall("NoCall_Foul");
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
        recentFoul = false;
    }

    public void CompareCall(Team refereeTeam)
    {
        if (!recentFoul)
        {
            CrowdManager.instance.BadCall("Call_NoFoul");
            //Don't reset players?
        }
        else
        {
            if (refereeTeam != currentFoul.team)
            {
                CrowdManager.instance.BadCall("RightFoul_WrongTeam");
            }
            else
            {
                print("Good call!");
                CrowdManager.instance.GoodCall();
            }

            recentFoul = false;
            //Reset players
        }
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
