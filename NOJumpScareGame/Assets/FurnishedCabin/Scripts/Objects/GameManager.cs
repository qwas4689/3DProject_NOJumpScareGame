using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public Text timeText;

    public GameObject Panel;
    public GameObject DieingPanel;
    public GameObject PanelDie;
    public GameObject Player;
    public GameObject DieCam;
    public GameObject easyModeMaker;
    public UnityEvent ChangeEasyMode = new UnityEvent();
    public UnityEvent ChangeNotEasyMode = new UnityEvent();

    private Pictures DeiCounts;
    public AudioSource MainSound;
    private Color dieingColorA;

    //public GameObject gameOverText;
    private float thisTime;
    private float timeSpeed = 0.0205f;
    private bool overTime;

    // private bool isGameOver;

    void Start()
    {
        DeiCounts = GameObject.Find("Pictures").GetComponent<Pictures>();
        thisTime = 22;
        Panel.SetActive(false);
        dieingColorA = DieingPanel.GetComponent<Image>().color;
        MainSound = GetComponent<AudioSource>();
        MainSound.Play();
    }

    void Update()
    {
        thisTimeText();
        SetPanel();
        dieing();
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
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            DieingPanel.SetActive(false);
            Panel.SetActive(true);
            MainSound.Pause();

            Time.timeScale = 0f;
        }
    }

    public void ExitPanel()
    {
        Panel.SetActive(false);
        DieingPanel.SetActive(true);
        MainSound.UnPause();
        Cursor.visible = false;

        Time.timeScale = 1f;
    }

    public void GoTitle()
    {
        Panel.SetActive(false);
        Time.timeScale = 1f;
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
            dieingColorA.a = 0.1f;
            DieingPanel.GetComponent<Image>().color = dieingColorA;
        }

        else if (DeiCounts.setActiveCounts == 3)
        {
            dieingColorA.a = 0.15f;
            DieingPanel.GetComponent<Image>().color = dieingColorA;
        }

        else if (DeiCounts.setActiveCounts == 4)
        {
            dieingColorA.a = 0.2f;
            DieingPanel.GetComponent<Image>().color = dieingColorA;
        }

        else if (DeiCounts.setActiveCounts == 5)
        {
            dieingColorA.a = 0.25f;
            DieingPanel.GetComponent<Image>().color = dieingColorA;
        }

        else if (DeiCounts.setActiveCounts == 6)
        {
            dieingColorA.a = 0.3f;
            DieingPanel.GetComponent<Image>().color = dieingColorA;
        }

        else if (DeiCounts.setActiveCounts == 7)
        {
            dieingColorA.a = 0.35f;
            DieingPanel.GetComponent<Image>().color = dieingColorA;
        }

        else if (DeiCounts.setActiveCounts == 8)
        {
            DieingPanel.SetActive(false);
            Player.SetActive(false);
            PanelDie.SetActive(true);
            DieCam.SetActive(true);
            MainSound.Pause();
        }

        else
        {
            dieingColorA.a = 0f;
            DieingPanel.GetComponent<Image>().color = dieingColorA;
        }
    }

    public void ToggleClick(bool IsOn)
    {
        if(IsOn)
        {
            ChangeEasyMode.Invoke();
        }
        else
        {
            ChangeNotEasyMode.Invoke();
        }
    }
}


