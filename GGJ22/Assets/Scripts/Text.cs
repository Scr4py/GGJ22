using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{

    public TextMeshPro text;
    public float TextVisibleSeconds;

    [SerializeField] PaulFX artTalk;
    [SerializeField] PaulFX ProgTalk;
    PlayerController player;

    [SerializeField]
    private string[] Texts;

    [SerializeField] bool OneTime;
    [SerializeField] bool play;

    private void Start()
    {
        text.gameObject.SetActive(false);
        player = GameObject.FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (OneTime)
            {
                if (player.isArtist)
                {
                    AudioManager.Instance.PlaySoundOneTime(artTalk);
                }
                else
                {
                    AudioManager.Instance.PlaySoundOneTime(ProgTalk);

                }

                if (Texts.Length > 1)
                {
                    int rnd = Random.Range(0, Texts.Length);
                    text.text = Texts[rnd];
                }
                else
                {
                    text.text = Texts[0];
                }
                text.gameObject.SetActive(true);
                OneTime = false;
            }
            else if (play)
            {
                if (player.isArtist)
                {
                    AudioManager.Instance.PlaySoundOneTime(artTalk);
                }
                else
                {
                    AudioManager.Instance.PlaySoundOneTime(ProgTalk);

                }

                if (Texts.Length > 1)
                {
                    int rnd = Random.Range(0, Texts.Length);
                    text.text = Texts[rnd];
                }
                else
                {
                    text.text = Texts[0];
                }
                text.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.gameObject.SetActive(false);
        }
    }



}
