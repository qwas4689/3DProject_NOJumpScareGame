using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text timeText;

    public GameObject Panel;
    public GameObject DieingPanel;
    public GameObject PanelDie;
    public GameObject Player;
    public GameObject DieCam;

    private Pictures DeiCounts;
    private Color dieingColorA;

    //public GameObject gameOverText;
    private float thisTime;
    private float timeSpeed = 0.02f;
    private bool overTime;

    // private bool isGameOver;

    void Start()
    {
        DeiCounts = GameObject.Find("Pictures").GetComponent<Pictures>();
        thisTime = 22;
        Panel.SetActive(false);
        dieingColorA = DieingPanel.GetComponent<Image>().color;

    }

    void Update()
    {
        thisTimeText();
        SetPanel();
        dieing();
        Debug.Log(DeiCounts.setActiveCounts);
        Debug.Log(dieingColorA.a);
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

    private void dieing()
    {
        if (DeiCounts.setActiveCounts == 1)
        {
            dieingColorA.a = 0.05f; 
            DieingPanel.GetComponent<Image>().color = dieingColorA;
        }

        else if (DeiCounts.setActiveCounts == 2)
        {
            dieingColorA.a = 0.15f;
            DieingPanel.GetComponent<Image>().color = dieingColorA;
        }

        else if (DeiCounts.setActiveCounts == 3)
        {
            dieingColorA.a = 0.25f;
            DieingPanel.GetComponent<Image>().color = dieingColorA;
        }

        else if (DeiCounts.setActiveCounts == 4)
        {
            dieingColorA.a = 0.35f;
            DieingPanel.GetComponent<Image>().color = dieingColorA;
        }

        else if (DeiCounts.setActiveCounts == 5)
        {
            dieingColorA.a = 0.45f;
            DieingPanel.GetComponent<Image>().color = dieingColorA;
        }

        else if (DeiCounts.setActiveCounts == 6)
        {
            dieingColorA.a = 0.55f;
            DieingPanel.GetComponent<Image>().color = dieingColorA;
        }

        else if (DeiCounts.setActiveCounts == 7)
        {
            dieingColorA.a = 0.65f;
            DieingPanel.GetComponent<Image>().color = dieingColorA;
        }

        else if (DeiCounts.setActiveCounts == 8)
        {
            DieingPanel.SetActive(false);
            Player.SetActive(false);
            PanelDie.SetActive(true);
            DieCam.SetActive(true);
        }

        else
        {
            dieingColorA.a = 0f;
            DieingPanel.GetComponent<Image>().color = dieingColorA;
        }
    }
}


