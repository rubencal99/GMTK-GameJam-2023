using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject CreditsPanel;
    public GameObject InstructionPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("ActualFinalScene");
    }

    public void OpenCredits()
    {
        CreditsPanel.SetActive(true);
    }

    public void OpenInstructions()
    {
        InstructionPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        CreditsPanel.SetActive(false);
    }

    public void CloseInstructions()
    {
        InstructionPanel.SetActive(false);
    }

    public void QuitGame()
    {

    }
}
