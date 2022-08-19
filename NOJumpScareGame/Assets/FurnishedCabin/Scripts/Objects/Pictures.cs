using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pictures : MonoBehaviour
{
    public GameObject[] gameObjects;
    List<GameObject> li = new List<GameObject>();
    List<GameObject> fixLi = new List<GameObject>();

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

        bool[] lists = new bool[6];
        int num = Random.Range(0, 6);

        while (!(fixLi.Count == gameObjects.Length))
        {
            if (lists[num] == false)
            {
                fixLi.Add(gameObjects[num]);
                lists[num] = true;
            }
            else
            {
                num = Random.Range(0, 6);
            }
        }
    }

    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(1f);
        int i = 0;
        while(true)
        {
            fixLi[i].SetActive(true);
            ++i;
            yield return new WaitForSeconds(10f);
            if (i == 5)
            {
                i = 0;
            }
        }
    }
}
