using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnTriggerEnter : MonoBehaviour
{
    [SerializeField] GameObject finishCanvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        finishCanvas.SetActive(true);
    }
}
