using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaterSwitch : MonoBehaviour
{


    private SwitchTwoRiddle switchTwoRiddle;
    [SerializeField] int number;
    // Start is called before the first frame update
    void Start()
    {
        switchTwoRiddle = gameObject.GetComponentInParent<SwitchTwoRiddle>();

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Stay");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Stay");

            if (Input.GetButtonDown("Interact"))
            {
                Debug.Log("Did Submit");
                switchTwoRiddle.SetBool(number);
            }
        }
    }
}
