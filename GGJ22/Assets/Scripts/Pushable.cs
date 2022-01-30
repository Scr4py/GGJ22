using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    bool isTriggered;
    PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (player.isArtist && isTriggered)
        {
            player.StartPush();
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            //player.StopPush();
            isTriggered = false;

    }
}
