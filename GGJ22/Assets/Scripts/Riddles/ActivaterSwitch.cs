using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaterSwitch : MonoBehaviour
{


    private SwitchTwoRiddle switchTwoRiddle;
    [SerializeField] int number;
    bool isTriggered;
    [SerializeField] Sprite activeSprite;
    SpriteRenderer spriteRenderer;
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        switchTwoRiddle = gameObject.GetComponentInParent<SwitchTwoRiddle>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && isTriggered && !playerController.isArtist)
        {
            Debug.Log("Did Submit");
            switchTwoRiddle.SetBool(number);
            spriteRenderer.sprite = activeSprite;
            EventManager.F_UseButton();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Stay");
        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
            Debug.Log("Player Stay");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggered = false;
            Debug.Log("Player Stay");
        }
    }
}

