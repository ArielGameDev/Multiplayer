using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/**
 * This component moves its object when the player clicks the arrow keys and use mouse.
 */
public class PlayerMover : MonoBehaviourPun
{
    [Tooltip("Speed of movement")] [SerializeField]
    float speed = 4f;

    [Tooltip("Speed of rotaion")] [SerializeField]
    float rotaionSpeed = 4f;

    [SerializeField] float sprintSpeed = 8f;
    private CharacterController controller;

    public Camera PlayerSee;
    [SerializeField] private KeyCode sprint;
    private float currentSpeed;


    private void Awake()
    {
        // #Critical
        // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
        DontDestroyOnLoad(this.gameObject);
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }

        if (Input.GetKey(sprint))
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = speed;
        }

        controller.SimpleMove(Vector3.forward * 0); //move player gravity
        float
            horizontal =
                Input.GetAxis("Horizontal"); // +1 if right arrow is pushed, -1 if left arrow is pushed, 0 otherwise
        float vertical = Input.GetAxis("Vertical"); // +1 if up arrow is pushed, -1 if down arrow is pushed, 0 otherwise
        float rotX = Input.GetAxis("Mouse X");
        float rotY = Input.GetAxis("Mouse Y");

        transform.Rotate(0, rotX, 0);

        Vector3 movementVector = new Vector3(horizontal, 0, vertical) * currentSpeed * Time.deltaTime;
        controller.Move(transform.rotation * movementVector);
        PlayerSee.transform.Rotate(-rotY * rotaionSpeed, 0, 0);
    }
}