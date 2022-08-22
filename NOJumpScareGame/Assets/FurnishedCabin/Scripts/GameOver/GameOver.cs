using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text dieText;
    

    private string[] YouDei;


    // Start is called before the first frame update
    void Start()
    {
        YouDei = new string[7];
        YouDei[0] = "Y";
        YouDei[1] = "O";
        YouDei[2] = "U";
        YouDei[3] = " ";
        YouDei[4] = "D";
        YouDei[5] = "I";
        YouDei[6] = "E";



        StartCoroutine(DIEText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DIEText()
    {
        for (int i = 0; i < 7; ++i)
        {
            dieText.text += YouDei[i];

            yield return new WaitForSeconds(0.3f);
        }

        
        yield break;
    }

}
