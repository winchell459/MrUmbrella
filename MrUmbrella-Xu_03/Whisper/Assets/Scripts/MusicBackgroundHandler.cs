using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBackgroundHandler : MonoBehaviour
{
    public static MusicBackgroundHandler StaticMBH;
    private AudioClip playingClip;
    public AudioSource AS;

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

            AS = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        
    }

    public void OnSceneEnd()
    {
        //fading = true;
        //fadeOut = true;

    }

   

    public void OnSceneStart(AudioClip clip)
    {
        if (!clip) return;

        fading = true;
        fadeOut = false;

        if(!playingClip || clip != playingClip)
        {
            playingClip = clip;
            if (!AS) AS = GetComponent<AudioSource>();
            AS.clip = clip;
            AS.loop = true;
            AS.Play();
        }
    }

    private void Update()
    {
        if (fading)
        {
            float volume = AS.volume;
            if (fadeOut)
            {
                
                volume -= fadeRate * Time.deltaTime;

            }
            else
            {
                volume += fadeRate * Time.deltaTime;
            }
            volume = Mathf.Clamp(volume, 0, 1);
            AS.volume = volume;
            if (fadeOut && volume <= 0 || !fadeOut && volume >= 1) fading = false; 
        }
    }
    
}
