using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScripts : MonoBehaviour
{
    private AudioSource audioSource;

    private float soundVolume = 0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = soundVolume;
        audioSource.Play();
    }

    void Update()
    {
        soundVolume += Time.deltaTime * 0.003f;
        audioSource.volume = soundVolume;

        if (soundVolume > 1f)
            soundVolume = 1f;
    }
}
