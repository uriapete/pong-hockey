using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Collections;
using System.Drawing;
using UnityEngine.UI;
using TMPro;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("Audio Clip")]
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    public TextMeshProUGUI musicTxt;
    public TextMeshProUGUI sfxTxt;
    public AudioClip backgroundMusic;
    public AudioClip paddleHit1SFX;
    public AudioClip paddleHit2SFX;
    public AudioClip scored1SFX;
    public AudioClip scored2SFX;
    


    void Start()
    {
        StartBGM();
    }

    public void StartBGM()
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

    // updates volume to provided when called
    public void UpdateMusicVolume(System.Single volume)
    {
        musicSource.volume = volume;
        musicTxt.text = "Music: " + Mathf.RoundToInt(volume * 100);
        
    }

    //updates SFX volume to provided when called
    public void UpdateSFXVolume(System.Single volume)
    {
        SFXSource.volume = volume;
        sfxTxt.text = "SFX:   " + Mathf.RoundToInt(volume * 100);
        
    }



}
