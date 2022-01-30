using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSwitch : MonoBehaviour
{
    public TextMeshPro text;
    [SerializeField] PaulFX artTalk;
    [SerializeField] PaulFX ProgTalk;
    PlayerController player;

    private void Start()
    {
        text.gameObject.SetActive(false);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            text.gameObject.SetActive(true);
        if (player.isArtist)
        {
            AudioManager.Instance.PlaySoundOneTime(artTalk);
        }
        else
        {
            AudioManager.Instance.PlaySoundOneTime(ProgTalk);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            text.gameObject.SetActive(false);
    }

}
