using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject tri;

    private int counts = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (counts > 2)
        {

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            tri.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameObject.SetActive(false);
                tri.SetActive(false);
                ++counts;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            tri.SetActive(false);
        }
    }

}
