using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private Sounds music;

    private void Awake()
    {
        music = GetComponent<Sounds>();
    }

    public void PlayMainTheme()
    {
        music.PlaySoundLoop(0);
    }

    public void PauseMainTheme()
    {
        if(music.audioSource.isPlaying)
        {
            music.audioSource.Pause();
        }
    }

    public void RoundStartStinger()
    {
        music.PlaySound(1);
    }    
    
    public void VictoryStinger()
    {
        music.PlaySoundLoop(3);
    }    
    
    public void DefeatStinger()
    {
        music.PlaySound(2);
    }
}
