using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject cam;
    public GameObject phone;

    private bool isActive = false;

    void Start()
    {
        cam.SetActive(false);
        phone.SetActive(false);
    }

    void Update()
    {
        camOnOff();
    }

    private void camOnOff()
    {
        if (Input.GetKeyDown(KeyCode.F) && isActive == false)
        {
            Debug.Log("ÄÑ±â");
            phone.SetActive(true);
            
            Invoke("camOn", 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.F) && isActive == true)
        {
            Debug.Log("²ô±â");
            cam.SetActive(false);
            
            Invoke("phoneOff", 0.5f);

        }
    }

    private void camOn()
    {
        cam.SetActive(true);
        isActive = true;
    }
    private void phoneOff()
    {
        phone.SetActive(false);
        isActive = false;
    }
}
