using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = Camera.main;    
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            float margin = Random.Range(0.0f, 0.3f);
            cam.rect = new Rect(margin, 0.0f, 1.0f - margin * 2.0f, 1.0f);
        }
    }
}
