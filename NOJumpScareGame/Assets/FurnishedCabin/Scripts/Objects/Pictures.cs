using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pictures : MonoBehaviour
{
    public GameObject[] gameObjects;
    public GameObject CSV;
    List<GameObject> li = new List<GameObject>();
    List<GameObject> fixLi = new List<GameObject>();

    public int setActiveCounts = 0;
    private float pictures;
        
    void Start()
    {
        randList();
        pictures = CSV.GetComponent<CsvCoolTime>().pictures;
        StartCoroutine(enumerator());
    }

    void randList()
    {
        for (int i = 0; i < gameObjects.Length; ++i)
        {
            li.Add(gameObjects[i]);
        }

        bool[] lists = new bool[gameObjects.Length];
        int num = Random.Range(0, gameObjects.Length);

        while (!(fixLi.Count == gameObjects.Length))
        {
            if (lists[num] == false)
            {
                fixLi.Add(gameObjects[num]);
                lists[num] = true;
            }
            else
            {
                num = Random.Range(0, gameObjects.Length);
            }
        }
    }

    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(30f);
        int i = 0;
        while (true)
        {
            fixLi[i].SetActive(true);
            if (fixLi[i].name == "Cube(5)")
            {
                fixLi[i].layer = 7;
            }
            else
            {
                fixLi[i].layer = 6;
            }

            ++setActiveCounts;
            ++i;
            yield return new WaitForSeconds(pictures);
            if (i == 6)
            {
                i = 0;
            }
        }
    }
}
