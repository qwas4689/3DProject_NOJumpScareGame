using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingKick : MonoBehaviour
{
    private Animator ani;

    void Start()
    {
        ani = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ani.SetTrigger("doFlyingKick");
        }
    }

    
}
