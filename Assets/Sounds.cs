using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip[] sounds;
    public AudioSource audioSource;

    public void PlaySound(int soundNum)
    {
        audioSource.PlayOneShot(sounds[soundNum]);
    }

    public void PlaySoundLoop(int soundNum)
    {
        audioSource.clip = sounds[soundNum];
        audioSource.loop = true;
        audioSource.Play();
    }
}
