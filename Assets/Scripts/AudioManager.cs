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
    public AudioClip scored1SFX;
    public AudioClip scored2SFX;

    void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    void Awake() //this insures that the audio manager doesn't duplicate itself on awake
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
