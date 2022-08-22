using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycasting : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;

    private Camera cam;
    public LayerMask layerMask;
    public LayerMask layerMask2;
    public GameObject LightSmudging;

    private float MaxRay = 7f;
    private float num = 0f;

    public GameObject tri;
    public GameObject cooltime;


    void Start()
    {
        cam = Camera.main;

    }

    void LateUpdate()
    {
        num += Time.deltaTime;

        ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        
        if (Physics.Raycast(ray, out hit, MaxRay, layerMask) || Physics.Raycast(ray, out hit, MaxRay, layerMask2))
        {
            Debug.DrawRay(ray.origin, ray.direction * 5, Color.green);
            tri.SetActive(true);
            if (hit.collider.tag == "Problem" || hit.collider.tag == "CantSee")
            {
                if (Input.GetKeyDown(KeyCode.E) && num > 5f)
                {
                    hit.collider.transform.gameObject.SetActive(false);
                    num = 0f;
                    LightSmudging.SetActive(true);
                }
                else if (Input.GetKeyDown(KeyCode.E) && num < 5f)
                {
                    cooltime.SetActive(true);
                }
            }
        }
        else
        {
            tri.SetActive(false);
            Debug.DrawRay(ray.origin, ray.direction * 5, Color.red);
            if (num > 0.05f)
            {
                LightSmudging.SetActive(false);
            }
        }
        if (num > 5f)
        {
            cooltime.SetActive(false);
        }
        
    }

    

}
