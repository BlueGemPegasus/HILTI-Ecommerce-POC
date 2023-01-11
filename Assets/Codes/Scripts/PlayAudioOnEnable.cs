using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayAudioOnEnable : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource audioSource;

    
    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
        audioSource.loop = true;
    }
    private void OnDisable()
    {
        audioSource.Stop();
    }
}
