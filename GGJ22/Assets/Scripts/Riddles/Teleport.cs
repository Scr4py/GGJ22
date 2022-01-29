using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Interactible
{
    public GameObject TeleportObject;

    public override void Activate()
    {
        TeleportObject.transform.position = this.gameObject.transform.position;
    }


}
