using System.Collections;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private Coroutine currentCoroutine;

    private void Awake()
    {
        //StartNewCoroutine(IntroRoutine());
    }

    private IEnumerator IntroRoutine()
    {
        float timeElapsed = 0f;
        float timeDuration = 5f;

        while(timeElapsed < timeDuration)
        {
            print("Ready?");
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        StartNewCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        float timeElapsed = 0f;
        float timeDuration = 1f;

        while (timeElapsed < timeDuration)
        {
            print("Go!!");
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    private void StartNewCoroutine(IEnumerator coroutine)
    {
        StopAllCoroutines();
        StartCoroutine(coroutine);
    }

    private void Update()
    {
        //Run the current state that is on top of the stack


        //if(Input.GetKeyDown(KeyCode.Q))
        //{

        //}
        //else if (Input.GetKeyDown(KeyCode.W))
        //{

        //}
        //else if (Input.GetKeyDown(KeyCode.F))
        //{

        //}
        //else if (Input.GetKeyDown(KeyCode.P))
        //{

        //}
    }
}
