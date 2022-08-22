using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearSound : MonoBehaviour
{
    private AudioSource gameClearSound;
    public GameObject End;

    private float wasteTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameClearSound = GetComponent<AudioSource>();
        gameClearSound.Play();
    }

    // Update is called once per frame
    void Update()
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
        }
    }
}
