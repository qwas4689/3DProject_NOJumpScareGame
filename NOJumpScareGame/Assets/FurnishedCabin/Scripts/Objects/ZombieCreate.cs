using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCreate : MonoBehaviour
{
    public GameObject zombieprefab;

    public GameObject[] create;

    private int num;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("createZombie");
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
        }

    }
}