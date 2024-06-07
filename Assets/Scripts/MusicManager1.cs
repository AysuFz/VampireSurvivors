using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip musicOnStart;
    [SerializeField] float timeToSwitch;
    AudioSource audioSource;
    AudioClip switchTo;
    float volume;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void Start()
    {
        Play(musicOnStart, true);
    }
   

    public void Play(AudioClip music, bool interrupt = false)
    {
        if(interrupt == true)
        {
            volume = 1f;
            audioSource.volume = volume;
            audioSource.clip = music;
            audioSource.Play();

        }
        else
        {
            switchTo = music;
            StartCoroutine(SmoothSwitchMusic());

        }
    }
    

    IEnumerator SmoothSwitchMusic()
    {
        volume = 1f;
        while(volume > 0)
        {
            volume -= Time.deltaTime / timeToSwitch;

            if(volume < 0) { volume = 0f; }

            audioSource.volume = volume;
            yield return new WaitForEndOfFrame();
        }
        Play(switchTo, true);
    }
}
