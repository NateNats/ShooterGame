using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManageer : MonoBehaviour
{
    private PlayerInput playerinput;
    public PlayerInput.OnFootActions onfoot;
    private PlayerMotor motor;
    private CameraLook cam;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Start is called before the first frame update
    void Awake()
    {
        playerinput = new PlayerInput();
        onfoot = playerinput.onFoot;
        onfoot.Sprint.performed += ctx => motor.Sprint();
        onfoot.Jump.performed += ctx => motor.jump();
        motor = GetComponent<PlayerMotor>();
        cam = GetComponent<CameraLook>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.moveProcess(onfoot.Movement.ReadValue<Vector2>());
    }

    void LateUpdate()
    {
        cam.lookProcess(onfoot.CameraLook.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onfoot.Enable();
    }

    private void OnDisable()
    { 
        onfoot.Disable();
    }
}
