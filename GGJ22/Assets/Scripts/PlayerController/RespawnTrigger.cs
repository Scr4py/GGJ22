using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    private Respawn respawn;
    [SerializeField] private GameObject respawnPos;

    private void Start()
    {
        respawn = FindObjectOfType<Respawn>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            respawn.SetRespawn(respawnPos.transform.position);
        }
    }
}
