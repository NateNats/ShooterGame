using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactable
{
    [SerializeField]
    private GameObject particle;

    protected override void Interact()
    {
        Destroy(particle);
        Instantiate(particle, transform.position, Quaternion.identity);
    }
}
