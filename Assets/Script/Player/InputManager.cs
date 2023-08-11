using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManageer : MonoBehaviour
{
    private PlayerInput playerinput;
    private PlayerInput.OnFootActions onfoot;

    // Start is called before the first frame update
    void Awake()
    {
        playerinput = new PlayerInput();
        onfoot = playerinput.onFoot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        onfoot.Enable();
    }

    private void onDisable()
    { 
        onfoot.Disable();
    }
}
