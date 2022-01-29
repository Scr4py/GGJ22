using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchRiddle : MonoBehaviour
{
    [SerializeField]
    private RiddleInteractable[] interactibles;
    [SerializeField] private SpriteRenderer[] lamps;
    [SerializeField] GameObject winObject;

    [SerializeField] private int[] order;
    int numberOfPressedSwitches;


    // Start is called before the first frame update
    bool isResetting;
    bool isFinished;

    public void SetInterActible(int numberOfOrder)
    {
        Debug.Log("order of Button " + numberOfOrder + " numberofPressedSwitches " + numberOfPressedSwitches);
        if (isResetting || isFinished)
            return;
        Debug.Log("Checked Interactable");
        if (order[numberOfPressedSwitches] == numberOfOrder)
        {
            Debug.Log("itWorked");
            lamps[numberOfPressedSwitches].color = Color.red;
            numberOfPressedSwitches++;
            if (numberOfPressedSwitches >= order.Length)
            {
                isFinished = true;
                //TODO: IMPLEMENT WIN LOGIK
                winObject.SetActive(false);
                Debug.Log("YOU WON BRO");
            }
        }
        else
        {
            StartCoroutine(ResetCoroutine());
        }

    }

    IEnumerator ResetCoroutine()
    {
        isResetting = true;
        yield return new WaitForSeconds(1.0f);
        ResetAll();
    }
    private void ResetAll()
    {
        for (int i = 0; i < interactibles.Length; i++)
        {
            interactibles[i].ResetSwitch();
            lamps[i].color = Color.white;
        }
        numberOfPressedSwitches = 0;
        isResetting = false;

    }


    // Update is called once per frame
    void Update()
    {

    }
}


