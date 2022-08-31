using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR.OpenVR;

public class OculusInput : MonoBehaviour
{
    public Transform centerCam;
    public Transform dot;

    void Start()
    {

    }

    void Update()
    {
        Ray ray = new Ray(centerCam.position, centerCam.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
          
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                dot.gameObject.SetActive(true);
                dot.position = hit.point;
            }
            else
            {
                dot.gameObject.SetActive(false);
            }
        }

        if (dot.gameObject.activeSelf)
        {
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                UnityEngine.UI.Button btn = hit.transform.GetComponent<UnityEngine.UI.Button>();

                if (btn != null)
                {
                    btn.onClick.Invoke();
                }
            }
        }
        else
        {
            dot.gameObject.SetActive(false);
        }
    }
    
}

