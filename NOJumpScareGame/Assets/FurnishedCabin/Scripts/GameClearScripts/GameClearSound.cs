using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearSound : MonoBehaviour
{
    private AudioSource gameClearSound;

    public GameObject End;
    public GameObject title;

    private float wasteTime = 0;

    void Start()
    {
        gameClearSound = GetComponent<AudioSource>();
        gameClearSound.Play();
        title.SetActive(false);
    }

    void Update()
    {
        gameClearSoundPitch();
    }

    private void gameClearSoundPitch()
    {
        wasteTime += Time.deltaTime;
        if (wasteTime > 5f)
        {
            gameClearSound.pitch += Time.deltaTime * (float)0.2;
            if (gameClearSound.pitch >= 3f)
            {
                gameClearSound.pitch = 3f;
            }
        }
        if (wasteTime >= 16f)
        {
            gameClearSound.Stop();
            End.SetActive(true);
            title.SetActive(true);
        }
    }
}
