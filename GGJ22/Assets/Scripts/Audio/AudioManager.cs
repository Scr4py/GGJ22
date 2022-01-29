using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource[] themeAudioSources;
    [SerializeField] private float onVolume;
    private void OnEnable()
    {
        EventManager.sceneSwitch += ChangeAudio;
        themeAudioSources[0].volume = onVolume;
        themeAudioSources[1].volume = 0.0f;

    }



    private void ChangeAudio()
    {
        if (themeAudioSources[0].volume >= onVolume)
        {
            themeAudioSources[0].volume = 0.0f;
            themeAudioSources[1].volume = onVolume;
        }
        else
        {
            themeAudioSources[1].volume = 0.0f;
            themeAudioSources[0].volume = onVolume;
        }
    }

    private void OnDisable()
    {
        EventManager.sceneSwitch -= ChangeAudio;

    }
}
