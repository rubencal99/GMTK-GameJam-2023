using System.Collections;
using UnityEngine;
using TMPro;

public class StageTimer : MonoBehaviour
{
    [SerializeField]
    private float timerValue = 60f;
    [SerializeField]
    private TMP_Text timerText;
    private bool isPaused = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            isPaused = !isPaused;
        }

        if(!isPaused)
        {
            if(timerValue > 0)
            {
                timerValue -= Time.deltaTime;
                timerText.text = Mathf.RoundToInt(timerValue).ToString();
            }
            else if(timerValue <= 0)
            {
                timerValue = 0;
                //Run victory sequence
            }
        }
    }
}