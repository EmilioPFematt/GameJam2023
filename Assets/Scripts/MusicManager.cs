using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioClip gameOverMusic;
    public AudioClip sineMusic;
    public static MusicManager Instance;

    private AudioSource audioSource;

    void Start()
    {
        Instance = this;
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
    public void ChangeToGameOver()
    {
        audioSource.clip = gameOverMusic; 
        audioSource.Play(); 
    }
    public void ChangeToSine(){
        audioSource.clip = sineMusic; 
        audioSource.Play(); 
    }
    public void StopMusic(){
        audioSource.Stop();
    }
}