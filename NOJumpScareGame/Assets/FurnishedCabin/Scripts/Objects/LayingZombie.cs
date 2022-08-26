using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayingZombie : MonoBehaviour
{
    private Pictures DieCounts;

    public GameObject zombieprefab;
    public GameObject[] create;

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
            zombieprefab.layer = 6;
            ++DieCounts.setActiveCounts;
        }
    }
}
