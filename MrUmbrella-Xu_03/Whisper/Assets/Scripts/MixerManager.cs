using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class MixerManager : MonoBehaviour
{
    public bool isCaveMix;
    public AudioMixerGroup mixer;
    public AudioMixerGroup CaveRainMixer;

    private void Update()
    {
        if (isCaveMix)
        {
            foreach (AudioSource aSource in FindObjectsOfType<AudioSource>())
            {
                if (aSource.transform.CompareTag("RainSoundEmitter"))
                {
                    aSource.outputAudioMixerGroup = CaveRainMixer;
                }
                else if (aSource.gameObject.GetComponent<MusicBackgroundHandler>())
                {
                    aSource.outputAudioMixerGroup = null;
                }
                else
                {
                    aSource.outputAudioMixerGroup = mixer;
                }
            }
        }
        
    }
}
