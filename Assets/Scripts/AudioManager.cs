using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("Audio Clip")]
    public AudioClip backgroundMusic;
    public AudioClip paddleHitSFX;

    void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    public void UpdateVolume(System.Single volume)
    {
        musicSource.volume = volume;
    }
}
