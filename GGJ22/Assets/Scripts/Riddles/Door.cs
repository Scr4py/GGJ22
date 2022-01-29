using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactible
{
    public GameObject DoorOpen;
    public override void Activate()
    {
        DoorOpen.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
