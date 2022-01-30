using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleInteractable : MonoBehaviour
{
    public int NumberInOrder;
    [SerializeField] Sprite activeSprite;
    [SerializeField] Sprite inActive;
    bool isTriggered;

    SpriteRenderer spriteRenderer;
    PlayerController playerController;
    [SerializeField] private SwitchRiddle switchRiddle;
    [SerializeField] private PaulFX Sound;
    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerController = FindObjectOfType<PlayerController>();

    }


    private void Update()
    {
        if (isTriggered && !playerController.isArtist && Input.GetButtonDown("Interact"))
        {

            EventManager.F_UseButton();
            switchRiddle.SetInterActible(NumberInOrder);
            AudioManager.Instance.PlaySoundOneTime(Sound);
            spriteRenderer.sprite = activeSprite;

        }
    }

    public void ResetSwitch()
    {
        spriteRenderer.sprite = inActive;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTriggered = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTriggered = false;

    }
}


