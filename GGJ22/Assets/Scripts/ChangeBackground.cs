using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBackground : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Sprite Programmer;
    [SerializeField] private Sprite Artist;

    void Start()
    {
        EventManager.changeBackground += EventManager_changeBackground;
    }

    private void EventManager_changeBackground(bool isArtist)
    {
        if (isArtist)
        {
            background.sprite = Artist;
        }
        else
        {
            background.sprite = Programmer;
        }
    }
}
