using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSwitch : MonoBehaviour
{
    public TextMeshPro text;

    private void Start()
    {
        text.gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            text.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            text.gameObject.SetActive(false);
    }

}
