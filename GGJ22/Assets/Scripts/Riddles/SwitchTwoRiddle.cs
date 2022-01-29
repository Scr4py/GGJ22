using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTwoRiddle : MonoBehaviour
{
    [SerializeField] bool activates;
    [SerializeField] bool[] hasSwitched;
    [SerializeField] GameObject activationObject;
    // Start is called before the first frame update
    void Start()
    {
        if (activates)
        {
            activationObject.SetActive(false);
        }
        else
        {
            activationObject.SetActive(true);

        }
    }

    public void SetBool(int number)
    {
        hasSwitched[number] = true;
        CheckIfComplete();
    }

    private void CheckIfComplete()
    {
        for (int i = 0; i < hasSwitched.Length; i++)
        {
            if (!hasSwitched[i])
            {
                return;
            }
        }

        if (activates)
        {
            activationObject.SetActive(true);
        }
        else
        {
            activationObject.SetActive(false);
        }
    }
}
