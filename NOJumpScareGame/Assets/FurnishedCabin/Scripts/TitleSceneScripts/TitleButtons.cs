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
    }

    public void SettingButtonClick()
    {
        SettingPanel.SetActive(true);
        prefab.SetActive(false);
    }

    public void SettingPanelExit()
    {
        Debug.Log("Aasd");
        prefab.SetActive(true);
        SettingPanel.SetActive(false);
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }

}
