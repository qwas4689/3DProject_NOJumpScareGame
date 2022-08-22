using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GAMECLEARTEXT : MonoBehaviour
{
    public Text timeText;
    public GameObject title;

    private string[] endGame;


    // Start is called before the first frame update
    void Start()
    {
        endGame = new string[13];
        endGame[0] = "G";
        endGame[1] = "A";
        endGame[2] = "m";
        endGame[3] = "E";
        endGame[4] = " ";
        endGame[5] = "C";
        endGame[6] = "L";
        endGame[7] = "E";
        endGame[8] = "A";
        endGame[9] = "R";
        endGame[10] = ".";
        endGame[11] = ".";
        endGame[12] = ".";

        title.SetActive(false);
        StartCoroutine(endText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator endText()
    {
        for (int i = 0; i < 13; ++i)
        {
            timeText.text += endGame[i];

            yield return new WaitForSeconds(1f);
        }

        title.SetActive(true);
        yield break;
    }

}
