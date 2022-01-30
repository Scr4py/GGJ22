using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Switch : Interactible
{
    public GameObject[] interactibleObject;

    bool triggerStay = false;

    private Interactible[] interactible;

    [SerializeField] private PaulFX ButtonpressSound;

    public void Start()
    {
      interactible = interactibleObject.Select(x => x.gameObject.GetComponent<Interactible>()).ToArray();
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
            EventManager.F_UseButton();
            for (int i = 0; i < interactible.Length; i++)
            {
                interactible[i].Activate();
                AudioManager.Instance.PlaySoundOneTime(ButtonpressSound);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        triggerStay = false;
    }
}
