using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SwitchRiddle : MonoBehaviour
{
    [SerializeField]

    private Interactible[] interactibles;

    [SerializeField]
    private int[] order;

    [SerializeField]
    private List<int> currentOrder = new List<int>();
    
    // Start is called before the first frame update
    void Start()
    {
        order = new int[interactibles.Length];
        FillList();

        SetSortOrder(order);
    }

    private void FillList()
    {
        for (int i = 0; i < interactibles.Length; i++)
        {
            currentOrder.Add(i);
        }
    }

    private void SetSortOrder(int[] order)
    {
        for (int i = 0; i < order.Length; i++)
        {
            int listIndex = Random.Range(0, currentOrder.Count);
            int rnd = currentOrder[listIndex];
            currentOrder.RemoveAt(listIndex);
            order[i] = rnd;
            interactibles[i].number = order[i];
        }
    }
}
