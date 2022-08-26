using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject cam;
    public GameObject phone;

    public Material[] mats;

    private bool isPhoneOn = false;
    private bool isPhoneOff = false;
    private bool isActive = false;

    void Start()
    {
        for (int i = 0; i < 2; ++i)
        {
            mats[i] = GetComponentInChildren<Renderer>().materials[i];
            mats[i].SetFloat("_DissolveAmount", 1f);
        }
        cam.SetActive(false);
    }

    void Update()
    {
        camOnOff();
        phoneAndCamOn();
    }

    private void camOnOff()
    {
        if (Input.GetKeyDown(KeyCode.F) && isActive == false)
        {
            isPhoneOn = true;
            isPhoneOff = false;
        }

        if (Input.GetKeyDown(KeyCode.F) && isActive == true)
        {
            isPhoneOn = false;
            isPhoneOff = true;
        }
    }

    private void phoneAndCamOn()
    {
        float[] amount = new float[2];

        for (int i = 0; i < 2; ++i)
        {
            amount[i] = mats[i].GetFloat("_DissolveAmount");
        }

        if (isPhoneOn)
        {
            Invoke("camOn", 0.8f);
            for (int i = 0; i < 2; ++i)
            {
                if (amount[i] > 0)
                {
                    mats[i].SetFloat("_DissolveAmount", amount[i] - (1f * Time.deltaTime));
                }
            }
            isActive = true;
        }

        if (isPhoneOff)
        {
            cam.SetActive(false);
            for (int i = 0; i < 2; ++i)
            {
                if (amount[i] < 1f)
                {
                    mats[i].SetFloat("_DissolveAmount", amount[i] + (1f * Time.deltaTime));
                }
            }
            isActive = false;
        }
    }

    void camOn() => cam.SetActive(true);
}
