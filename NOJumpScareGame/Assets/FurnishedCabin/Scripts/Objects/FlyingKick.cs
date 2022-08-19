using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingKick : MonoBehaviour
{
    private Animator ani;

    //public Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ani.SetTrigger("doFlyingKick");
        }
    }

    
}
