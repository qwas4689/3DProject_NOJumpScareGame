using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text timeText;

    public GameObject Panel;

    //public GameObject gameOverText;
    private float thisTime;
    private float timeSpeed = 1f;
    private bool overTime;

    // private bool isGameOver;

    void Start()
    {
        thisTime = 22;
        Panel.SetActive(false);
    }

    void Update()
    {
        thisTimeText();
        SetPanel();
    }

    private void thisTimeText()
    {
        thisTime += Time.deltaTime * (float)timeSpeed;
        if (thisTime > 24)
        {
            thisTime = 0;
            overTime = true;
        }
        if (thisTime >= 6 && overTime == true)
        {
            SceneManager.LoadScene("GameClear");
        }

        timeText.text = (int)thisTime + " : 00";
    }

    private void SetPanel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ExitPanel()
    {
        Panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GoTitle()
    {
        Panel.SetActive(false);
        SceneManager.LoadScene("TitleScene");
    }
}


