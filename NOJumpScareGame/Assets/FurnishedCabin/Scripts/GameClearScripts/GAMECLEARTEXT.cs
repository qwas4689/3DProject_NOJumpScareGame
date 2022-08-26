using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GAMECLEARTEXT : MonoBehaviour
{
    public Text timeText;
    

    private string[] endGame;


    // Start is called before the first frame update
    void Start()
    {
        endGame = new string[16];
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
        endGame[13] = ".";
        endGame[14] = ".";
        endGame[15] = ".";


        StartCoroutine(endText());
    }

    IEnumerator endText()
    {
        for (int i = 0; i < 16; ++i)
        {
            timeText.text += endGame[i];

            yield return new WaitForSeconds(1f);
        }
        
        yield break;
    }

}
