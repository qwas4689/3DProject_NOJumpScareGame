using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour
{
    public void GoTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
