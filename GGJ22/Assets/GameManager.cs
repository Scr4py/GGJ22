using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject artLvl;
    [SerializeField]
    private GameObject progLvl;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.sceneSwitch += EventManager_sceneSwitch;
        if (!artLvl.activeInHierarchy)
        {
            artLvl.SetActive(true);
        }
        if (progLvl.activeInHierarchy)
        {
            progLvl.SetActive(false);
        }
    }

    private void EventManager_sceneSwitch()
    {
        if (artLvl.activeSelf)
        {
            progLvl.SetActive(true);
            artLvl.SetActive(false);
        }
        else 
        {
            progLvl.SetActive(false);
            artLvl.SetActive(true);
        }
    }
}

