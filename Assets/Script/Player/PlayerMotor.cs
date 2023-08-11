using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private Boolean isGrounded;
    private Boolean isSprint = false;
    public float gravity = -9.8f;
    private float speed = 5f;
    public float jumpHeight = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void moveProcess(Vector2 input) 
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * Time.deltaTime * speed);
        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y < 0) 
        {
            playerVelocity.y = -2f;
        }

        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Sprint()
    {
        isSprint = !isSprint;
        if (isSprint)
        {
            speed = 12f;
        } else
        {
            speed = 5f;
        }
    }

    public void jump()
    {
        if(isGrounded) 
        {
            playerVelocity.y = MathF.Sqrt(jumpHeight * -1f * gravity);
        }
    }
}
