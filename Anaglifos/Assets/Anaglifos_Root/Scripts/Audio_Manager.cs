using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    
    
    [Header("_________Audio Source__________")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("_________Clips_________")]
    public AudioClip background;
    public AudioClip Color;
    public AudioClip LevelStart;
    public AudioClip PickUp;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
        PlaySFX(LevelStart);
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
