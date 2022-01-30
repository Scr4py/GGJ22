using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    PlayerController player;
    Vector2 respawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void SetRespawn(Vector2 position)
    {
        respawnPosition = position;
    }

    public void DoRespawn()
    {
        player.gameObject.transform.position = respawnPosition;
    }


}
