using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pictures : MonoBehaviour
{
    public GameObject[] gameObjects;
    List<GameObject> li = new List<GameObject>();
    List<GameObject> fixLi = new List<GameObject>();

    public int setActiveCounts = 0;

        
    void Start()
    {
        randList();
        StartCoroutine(enumerator());
    }

    void Update()
    {
            
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
        yield return new WaitForSeconds(10f);
        int i = 0;
        while(true)
        {
            fixLi[i].SetActive(true);
            ++setActiveCounts;
            ++i;
            yield return new WaitForSeconds(10f);
            if (i == 5)
            {
                i = 0;
            }
        }
    }
}
