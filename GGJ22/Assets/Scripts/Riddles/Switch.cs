using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Switch : Interactible
{
    public GameObject[] interactibleObject;

    bool triggerStay = false;

    private Interactible[] interactible;


    public void Start()
    {
      interactible = interactibleObject.Select(x => x.gameObject.GetComponent<Interactible>()).ToArray();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Inside");
            triggerStay = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggerStay)
        {
            for (int i = 0; i < interactible.Length; i++)
            {
                interactible[i].Activate();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        triggerStay = false;
    }
}
