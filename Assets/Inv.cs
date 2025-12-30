using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inv : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject inventory;
    private bool inventoryOn;

    private void Awake()
    {
        inventoryOn = false;
    }

    public void Chest()
    {
        if (inventoryOn == false)
        {
            inventoryOn = true;
            inventory.SetActive(true);
        }
        else if (inventoryOn == true)
        {
            inventoryOn = false;
            inventory.SetActive(false);
        }
    }
}
