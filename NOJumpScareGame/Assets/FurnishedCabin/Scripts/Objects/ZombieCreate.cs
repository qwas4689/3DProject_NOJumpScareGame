using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCreate : MonoBehaviour
{
    private Pictures DeiCounts;

    public GameObject zombieprefab;
    public GameObject[] create;

    private int num;

    void Start()
    {
        StartCoroutine(createZombie());
        DeiCounts = GameObject.Find("Pictures").GetComponent<Pictures>();
    }

    IEnumerator createZombie()
    {
        while (true)
        {
            yield return new WaitForSeconds(60f);
            num = Random.Range(0, 5);
            Instantiate(zombieprefab, create[num].transform.position, create[num].transform.rotation);
            zombieprefab.layer = 6;
            ++DeiCounts.setActiveCounts;
        }

    }
}
