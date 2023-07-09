using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    public StageTimer stageTimer;
    public GameObject flagPanel;
    public GameObject referee;

    public MusicManager musicManager;

    public GameObject victoryPanel;
    public GameObject defeatPanel;
    public GameObject pausePanel;

    private Coroutine currentCoroutine;

    private void Awake()
    {
        instance = this;
        StartNewCoroutine(IntroRoutine());
    }

    public void RoundStart()
    {
        musicManager.RoundStartStinger();
        CrowdManager.instance.sounds.PlaySoundLoop(2);
    }

    public void WhistleBlown()
    {
        stageTimer.PauseTimer();
        FoulManager.instance.StopCountdown();
        musicManager.PauseMainTheme();
        flagPanel.SetActive(true);
    }

    public void AnnounceCall()
    {
        flagPanel.SetActive(false);
        musicManager.PlayMainTheme();
        //Play animation/sound, pause.
        //Crowd reaction
        referee.GetComponent<AgentInput>().enabled = true;
        stageTimer.UnPauseTimer();
    }

    public void Victory()
    {
        victoryPanel.SetActive(true);
        musicManager.VictoryStinger();
    }

    public void Defeat()
    {
        defeatPanel.SetActive(true);
        musicManager.DefeatStinger();
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

        RoundStart();

        while (timeElapsed < timeDuration)
        {
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        //Enable Player control
        //Enable Referee control
        musicManager.PlayMainTheme();
        CrowdManager.instance.sounds.PlaySoundLoop(4);  //Crowd loop
    }

    private IEnumerator StartGame()
    {
        float timeElapsed = 0f;
        float timeDuration = 1f;

        while (timeElapsed < timeDuration)
        {
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    private void StartNewCoroutine(IEnumerator coroutine)
    {
        StopAllCoroutines();
        StartCoroutine(coroutine);
    }
}
