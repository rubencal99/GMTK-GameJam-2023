using System.Collections;
using UnityEngine;

public class FoulTracker : MonoBehaviour
{
    private bool recentFoul = false;
    private Foul currentFoul;
    private IEnumerator currentCoroutine;

    public void FoulHappened(Foul foul)
    {
        if(currentCoroutine == null)
        {
            currentFoul = foul;
            recentFoul = true;
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
    }
}

public struct Foul
{
    enum FoulType { BALLOOB, PLAYEROOB};
    FoulType foulType;
    bool team;
}
