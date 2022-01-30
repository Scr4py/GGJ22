using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VasenRätsel : MonoBehaviour
{
    private SpriteRenderer renderer;

    [SerializeField] private Sprite _activated;

    [SerializeField] private GameObject BridgeToActivate;


    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        BridgeToActivate.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            renderer.sprite = _activated;
            BridgeToActivate.gameObject.SetActive(true);
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -2;
        }
    }
}
