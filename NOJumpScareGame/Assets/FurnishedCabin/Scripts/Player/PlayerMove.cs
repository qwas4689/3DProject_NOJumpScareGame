using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    private CharacterController charController;
    private AudioSource playerWalkSound;

    public GameObject PanelDie;
    public GameObject DieingPanel;
    public GameObject DieCam;

    [SerializeField] 
    private float movementSpeed = 4f;
    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        playerWalkSound = GetComponent<AudioSource>();
        playerWalkSound.Play();
        playerWalkSound.loop = true;
    }

    private void Update()
    {
        PlayerMovement();
        PlayerWalkSound();
    }

    private void PlayerMovement()
    {
        float vertInput = Input.GetAxis("Vertical") * movementSpeed;     
        //CharacterController.SimpleMove() applies deltaTime
        float horizInput = Input.GetAxis("Horizontal") * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        //simple move applies delta time automatically
        charController.SimpleMove(forwardMovement + rightMovement);
    }

    private void PlayerWalkSound()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            playerWalkSound.UnPause();
        }
        else
        {
            playerWalkSound.Pause();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FlyingKick")
        {
            DieingPanel.SetActive(false);
            gameObject.SetActive(false);
            PanelDie.SetActive(true);
            DieCam.SetActive(true);
        }
    }

    
}
