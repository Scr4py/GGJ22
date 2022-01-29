using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : Interactible
{
    public Transform Start;
    public Transform End;

    public float Speed = 1.0f;
    public float journeyLength = 1.0f;

    bool activated = false;
    float counter = 0;

    public override void Activate()
    {
        activated = true;
    }

    private void Update()
    {
        if (activated)
        {
            counter += Time.deltaTime;
            float distance = Mathf.PingPong(counter, journeyLength / Speed);
            this.transform.position = Vector3.Lerp(Start.position, End.position, distance / journeyLength);
        }
    }
}
