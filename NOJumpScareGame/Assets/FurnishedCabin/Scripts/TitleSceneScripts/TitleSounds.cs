using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSounds : MonoBehaviour
{
    private AudioSource TitleSound;

    public Slider SetVolume;

    void Start()
    {
        TitleSound = GetComponent<AudioSource>();
        TitleSound.loop = true;
        TitleSound.Play();
    }

    void Update()
    {
        SoundSlider();
    }

    public void SoundSlider() => TitleSound.volume = SetVolume.value;
}
