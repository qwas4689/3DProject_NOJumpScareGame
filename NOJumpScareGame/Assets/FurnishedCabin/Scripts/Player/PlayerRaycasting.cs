using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycasting : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;

    private Camera cam;
    private AudioSource cameraSound;
    private Pictures DeiCounts;

    public LayerMask layerMask;
    public LayerMask layerMask2;
    public GameObject LightSmudging;
    public AudioClip cameraClip;
    public GameObject phoneCam;
    public GameObject phoneCamWalking;
    public GameObject phoneCamCooltimeOver;


    private float MaxRay = 7f;
    private float num = 0f;
    private bool isInputE = false;
    private GameObject hitTarget;


    public GameObject tri;
    public GameObject cooltime;


    void Start()
    {
        cam = Camera.main;
        cameraSound = GetComponent<AudioSource>();
        DeiCounts = GameObject.Find("Pictures").GetComponent<Pictures>();
        phoneCam.transform.localRotation = phoneCamCooltimeOver.transform.localRotation;
    }

    void LateUpdate()
    {
        num += Time.deltaTime;

        ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (num > 0.05f)
        {
            LightSmudging.SetActive(false);
        }
        if (Physics.Raycast(ray, out hit, MaxRay, layerMask) || Physics.Raycast(ray, out hit, MaxRay, layerMask2))
        {
            Debug.DrawRay(ray.origin, ray.direction * 5, Color.green);
            if (hit.collider.tag == "Problem" || hit.collider.tag == "CantSee")
            {
            tri.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) && num > 5f && isInputE == false)
                {
                    hit.collider.gameObject.layer = 7;
                    hitTarget = hit.collider.transform.gameObject;

                    num = 0f;
                    isInputE = true;
                    tri.SetActive(false);
                    LightSmudging.SetActive(true);

                    cameraSound.PlayOneShot(cameraClip);
                    --DeiCounts.setActiveCounts;

                    phoneCam.GetComponent<PlayerLook>().enabled = false;
                    phoneCam.transform.SetParent(phoneCamWalking.transform);
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
            
        }
        if (num > 5f && isInputE == true)
        {
            hitTarget.SetActive(false);
            cooltime.SetActive(false);
            isInputE = false;
            phoneCam.GetComponent<PlayerLook>().enabled = true;
            phoneCam.transform.SetParent(phoneCamCooltimeOver.transform);
            phoneCam.transform.localPosition = phoneCamCooltimeOver.transform.localPosition;
            phoneCam.transform.localRotation = phoneCamCooltimeOver.transform.localRotation;
        }
        
    }

 
    

}
