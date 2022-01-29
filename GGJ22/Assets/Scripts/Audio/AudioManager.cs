using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct PaulFX
{
    public AudioClip Sound;
    [Range(0.0f, 1.0f)]
    public float volume;
}
public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

    [SerializeField] AudioSource[] themeAudioSources;
    [SerializeField] private float onVolume;
    PlayerController playerController;

    [SerializeField] AudioSource jumpAudioSource;
    [SerializeField] PaulFX jumpArtist;
    [SerializeField] PaulFX jumpProgger;
    AudioSource[] OneTimeAudioSources;


    private void OnEnable()
    {
        EventManager.sceneSwitch += ChangeAudio;
        themeAudioSources[0].volume = onVolume;
        themeAudioSources[1].volume = 0.0f;

    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void PlayJumpSound()
    {
        if (playerController.isArtist)
        {

            jumpAudioSource.PlayOneShot(jumpArtist.Sound, jumpArtist.volume);
        }
        else
        {
            jumpAudioSource.PlayOneShot(jumpArtist.Sound, jumpProgger.volume);
        }
    }

    public void PlaySoundOneTime(PaulFX sound)
    {
        foreach (var source in OneTimeAudioSources)
        {
            if (!source.isPlaying)
            {
                source.PlayOneShot(sound.Sound, sound.volume);
                break;
            }
        }
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
