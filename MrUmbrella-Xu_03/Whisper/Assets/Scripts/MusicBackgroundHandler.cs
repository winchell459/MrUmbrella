using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBackgroundHandler : MonoBehaviour
{
    public static MusicBackgroundHandler StaticMBH;

    private AudioClip playingClip;
    private AudioSource audioSource;

    private bool fading;
    private float fadeRate = 0.1f;
    private float fadeStart;
    private bool fadeOut = true;

    private void Awake()
    {
        if (!StaticMBH)
        {
            StaticMBH = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (fading)
        {
            float volume = audioSource.volume;
            if (fadeOut)
            {
                volume -= fadeRate * Time.deltaTime;
            }
            else
            {
                volume += fadeRate * Time.deltaTime;
            }

            volume = Mathf.Clamp(volume, 0, 1);
            audioSource.volume = volume;
            if (fadeOut && volume <= 0 || !fadeOut && volume >= 1) fading = false;
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        Debug.Log("Scene Loaded: " + level);
    }

    public void OnSceneEnd()
    {
        fading = true;
        fadeOut = true;
    }

    public void OnSceneStart(AudioClip clip)
    {
        fading = true;
        fadeOut = false;

        if (!playingClip || clip != playingClip)
        {
            playingClip = clip;
            audioSource.clip = clip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
    //IEnumerator FadeMusic()
    //{

    //}




}
