using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactible
{
    public GameObject interactibleObject;

    bool triggerStay = false;

    private Interactible interactible;


    public void Start()
    {
      interactible = interactibleObject.GetComponent<Interactible>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            triggerStay = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggerStay)
        {
            //interactible.Activate();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        triggerStay = false;
    }
}
