using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    // Start is called before the first frame update
    Respawn respawn;
    void Start()
    {
        respawn = FindObjectOfType<Respawn>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            respawn.DoRespawn();
        }
    }
}
