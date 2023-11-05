using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip menuMusic;
    public AudioClip gameMusic;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ChangeToMenuMusic();
    }

    public void ChangeToGameMusic()
    {
        audioSource.clip = gameMusic; 
        audioSource.Play(); 
    }

    public void ChangeToMenuMusic()
    {
        audioSource.clip = menuMusic; 
        audioSource.Play(); 
    }
}