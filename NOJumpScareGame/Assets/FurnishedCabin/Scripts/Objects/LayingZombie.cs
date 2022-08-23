using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayingZombie : MonoBehaviour
{
    public GameObject zombieprefab;

    public GameObject[] create;

    private Pictures DieCounts;

    void Start()
    {
        StartCoroutine(layingZombie());
        DieCounts = GameObject.Find("Pictures").GetComponent<Pictures>();
    }

    IEnumerator layingZombie()
    {
        while (true)
        {
            yield return new WaitForSeconds(120f);

            int num;
            num = Random.Range(0, 2);
            Instantiate(zombieprefab, create[num].transform.position, create[num].transform.rotation);
            ++DieCounts.setActiveCounts;

        }

    }
}
