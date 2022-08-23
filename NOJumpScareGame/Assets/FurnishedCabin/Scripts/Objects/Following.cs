using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Following : MonoBehaviour
{
    private float moveSpeed = 0.5f;
    private NavMeshAgent navMeshAgent;
    private Animator ani;
    private bool isFind;
    private AudioSource zombieSound;

    private Transform target;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        zombieSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        target = GameObject.Find("PlayerFPS").transform;

        if (isFind)
        {
            moveTo(target);
        }
    }

    public void moveTo(Transform goalPosition)
    {
        StopCoroutine("onMove");

        navMeshAgent.speed = moveSpeed;

        navMeshAgent.SetDestination(goalPosition.position);

        StartCoroutine("onMove");
    }

    IEnumerator onMove()
    {
        while (true)
        {
            if (Vector3.Distance(navMeshAgent.destination, transform.position) < 0.1f)
            {
                transform.position = navMeshAgent.destination;

                navMeshAgent.ResetPath();

                break;
            }

            yield return null;
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            zombieSound.Play();
            StopCoroutine(scream());
            StartCoroutine(scream());
        }
    }

    IEnumerator scream()
    {
        while (true)
        {
            transform.LookAt(target);
            ani.SetTrigger("doScream");

            yield return new WaitForSeconds(2.5f);

            isFind = true;

            yield break;
        }

    }
}
