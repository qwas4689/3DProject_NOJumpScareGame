using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Following : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator ani;
    private AudioSource zombieSound;
    private Transform target;

    private float moveSpeed = 0.5f;
    private bool isFind;

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
        navMeshAgent.speed = moveSpeed;

        navMeshAgent.SetDestination(goalPosition.position);
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
