using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public int number;
    public bool activated;
    public virtual void Activate()
    {
        Debug.Log("Diese Methode ist noch nicht implementiert");
    }
    
}
