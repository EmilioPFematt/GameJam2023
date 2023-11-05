using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; 
    public AudioClip [] sounds;
    private AudioSource audioSource;
    // Start is called before the first frame update
    private void Start()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    public void playSound(int sound){
        audioSource.PlayOneShot(sounds[sound]);
    }
}
