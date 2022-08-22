using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    private CharacterController charController;
    private AudioSource playerWalkSound;


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
    }

    private void Update()
    {
        PlayerMovement();
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
}
