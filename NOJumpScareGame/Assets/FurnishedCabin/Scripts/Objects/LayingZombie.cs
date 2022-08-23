using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayingZombie : MonoBehaviour
{
    public GameObject zombieprefab;

    public GameObject[] create;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(layingZombie());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator layingZombie()
    {
        while (true)
        {
            yield return new WaitForSeconds(120f);

            int num;
            num = Random.Range(0, 2);
            Instantiate(zombieprefab, create[num].transform.position, create[num].transform.rotation);

        }

    }
}
