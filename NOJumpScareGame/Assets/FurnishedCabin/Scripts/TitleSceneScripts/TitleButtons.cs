using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleButtons : MonoBehaviour
{
    public GameObject SettingPanel;
    public GameObject prefab;

    public void StartButtonClick()
    {
        SceneManager.LoadScene("MainSCenes");

        Time.timeScale = 1f;
    }

    public void SettingButtonClick()
    {
        SettingPanel.SetActive(true);
        prefab.SetActive(false);
    }

    public void SettingPanelExit()
    {
        prefab.SetActive(true);
        SettingPanel.SetActive(false);
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }

}
