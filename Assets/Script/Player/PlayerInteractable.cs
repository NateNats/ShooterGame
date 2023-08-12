using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInteractable : MonoBehaviour
{
    [SerializeField]
    private float distance = 1.5f;
    private Camera cam;
    private InputManageer inputManager;
    public LayerMask mask;
    private PlayerUI playerUI;

    public void Start()
    {
        cam = GetComponent<CameraLook>().cam;
        inputManager = GetComponent<InputManageer>();
        playerUI = GetComponent<PlayerUI>();
    }

    public void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, distance, mask)) 
        {
            playerUI.UpdateText(hit.collider.GetComponent<Interactable>().promptMessage);

            if (inputManager.onfoot.Interact.triggered)
            {
                Debug.Log("\"You hit this thing\"");
            }
        }
    }
}
