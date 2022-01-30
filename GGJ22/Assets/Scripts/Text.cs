using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{

    public TextMeshPro text;
    public float TextVisibleSeconds;

    [SerializeField]
    private string[] Texts;

    private void Start()
    {
        text.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine("StopText");
        }
    }



    IEnumerator StopText()
    {
        yield return new WaitForSeconds(TextVisibleSeconds);
        text.gameObject.SetActive(false);
    }


}
