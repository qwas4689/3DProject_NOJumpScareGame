using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSounds : MonoBehaviour
{
    private AudioSource TitleSound;

    public Slider SetVolume;

    // Start is called before the first frame update
    void Start()
    {
        TitleSound = GetComponent<AudioSource>();
        TitleSound.loop = true;
        TitleSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        SoundSlider();
    }

    public void SoundSlider()
    {
        TitleSound.volume = SetVolume.value;
    }
}
