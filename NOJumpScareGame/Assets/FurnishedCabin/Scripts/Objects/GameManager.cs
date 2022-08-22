using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text timeText;

    //public GameObject gameOverText;
    private float thisTime;
    private float timeSpeed = 1f;
    private bool overTime;
    private bool isGameOver;

    void Start()
    {
        thisTime = 22;
        isGameOver = false;
    }

    void Update()
    {
        thisTimeText();
    }

    private void thisTimeText()
    {
        thisTime += Time.deltaTime * (float)timeSpeed;
        if (thisTime > 25)
        {
            thisTime = 1;
            overTime = true;
        }
        if (thisTime >= 6 && overTime == true)
        {
            SceneManager.LoadScene("GameClear");
        }

        timeText.text = (int)thisTime + " : 00";
    }
}


