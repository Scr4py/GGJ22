using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRiddle : MonoBehaviour
{
    [SerializeField]
    private Interactible[] interactibles;

    private int[] order;

    // Start is called before the first frame update
    void Start()
    {
        order = new int[interactibles.Length];
        SetSortOrder(order);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void SetSortOrder(int[] order)
    {
        for (int i = 0; i < order.Length; i++)
        {
            order[i] = Random.Range(0, order.Length - 1);

            interactibles[i].number = order[i];
        }
    }
}
