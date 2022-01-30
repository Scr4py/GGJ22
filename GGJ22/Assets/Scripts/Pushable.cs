using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    bool isTriggered;
    PlayerController player;
    [SerializeField] PaulFX push;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (player.isArtist && isTriggered)
        {
            player.StartPush();
            if (!playsSound)
            {
                StartCoroutine(WaitForSound());

            }
        }
        else
        {
            player.StopPush();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && player.isArtist)
        {
            isTriggered = true;
        }
        //player.StartPush();
    }

    bool playsSound;
    IEnumerator WaitForSound()
    {
        playsSound = true;
        AudioManager.Instance.PlaySoundOneTime(push);
        yield return new WaitForSeconds(2.0f);
        playsSound = false;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            //player.StopPush();
            isTriggered = false;

    }
}
