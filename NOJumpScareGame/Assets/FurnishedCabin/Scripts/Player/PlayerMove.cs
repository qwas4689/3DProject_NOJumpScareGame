using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    private CharacterController charController;
    private AudioSource playerWalkSound;

    public GameObject PanelDie;
    public GameObject DieingPanel;
    public GameObject DieCam;
    public GameObject gameManager;
    public GameObject Cam;

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
        playerWalkSound.Pause();
    }

    private void Update()
    {
        PlayerMovement();
        PlayerWalkSound();
        LookAround();
    }

    private void PlayerMovement()
    {
        float vertInput = Input.GetAxis("Vertical") * movementSpeed;
        float horizInput = Input.GetAxis("Horizontal") * movementSpeed;

        Vector3 forwardMovement = Cam.transform.forward * vertInput;
        Vector3 rightMovement = Cam.transform.right * horizInput;

        //Vector3 forwardMovement = transform.forward * vertInput;
        //Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);
    }

    private void PlayerWalkSound()
    {
        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))
        {
            Vector2 thumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

            if (thumbstick.x < 0 || thumbstick.x > 0 || thumbstick.y < 0 || thumbstick.y > 0)
            {
                playerWalkSound.UnPause();
            }
            else
            {
                playerWalkSound.Pause();
            }
        }
    }

    private void LookAround()
    {
        if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick))
        {
            Vector2 thumbstick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

            if (thumbstick.x < 0)
            {
                gameObject.transform.Rotate(0, thumbstick.x * 2, 0);
            }
            else if (thumbstick.x > 0)
            {
                gameObject.transform.Rotate(0, thumbstick.x * 2, 0);
            }

            if (thumbstick.y < 0)
            {
                gameObject.transform.Rotate(0, thumbstick.y, 0);
            }
            else if (thumbstick.y > 0)
            {
                gameObject.transform.Rotate(0, thumbstick.y, 0);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FlyingKick")
        {
            gameManager.GetComponent<GameManager>().MainSound.Pause();
            SceneManager.LoadScene("Die");
        }
    }


}
