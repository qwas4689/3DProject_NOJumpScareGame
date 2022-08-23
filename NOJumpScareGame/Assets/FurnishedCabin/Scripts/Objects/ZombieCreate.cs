using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCreate : MonoBehaviour
{
    public GameObject zombieprefab;

    public GameObject[] create;

    private Pictures DeiCounts;
    private int num;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(createZombie());
        DeiCounts = GameObject.Find("Pictures").GetComponent<Pictures>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator createZombie()
    {
        while (true)
        {

            num = Random.Range(0, 5);
            Instantiate(zombieprefab, create[num].transform.position, create[num].transform.rotation);
            yield return new WaitForSeconds(60f);
            ++DeiCounts.setActiveCounts;
        }

    }
}
