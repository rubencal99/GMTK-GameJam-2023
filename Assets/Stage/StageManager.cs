using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    public StageTimer stageTimer;
    public GameObject flagPanel;
    public GameObject referee;

    public GameObject victoryPanel;
    public GameObject defeatPanel;
    public GameObject pausePanel;

    private Coroutine currentCoroutine;

    private void Awake()
    {
        instance = this;
        //StartNewCoroutine(IntroRoutine());
    }

    public void WhistleBlown()
    {
        stageTimer.PauseTimer();
        FoulManager.instance.StopCountdown();
        flagPanel.SetActive(true);
    }

    public void AnnounceCall()
    {
        flagPanel.SetActive(false);
        //Play animation/sound, pause.
        //Crowd reaction
        //Reset players
        referee.GetComponent<AgentInput>().enabled = true;
    }

    public void Victory()
    {
        victoryPanel.SetActive(true);
    }

    public void Defeat()
    {
        defeatPanel.SetActive(true);
    }

    public void ReturnToTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void OpenPause()
    {
        pausePanel.SetActive(true);
    }

    public void ClosePause()
    {
        pausePanel.SetActive(false);
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
