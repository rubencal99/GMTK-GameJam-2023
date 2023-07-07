using UnityEngine;
using TMPro;

public class StageTimer : MonoBehaviour
{
    [SerializeField]
    private float timerValue = 60f;
    [SerializeField]
    private TMP_Text timerText;

    private void Update()
    {
        if(timerValue > 0)
        {
            timerValue -= Time.deltaTime;
            timerText.text = timerValue.ToString();
        }
        else if(timerValue <= 0)
        {
            timerValue = 0;
            //Run victory sequence
        }
    }
}