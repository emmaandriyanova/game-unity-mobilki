using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;




private void Start()
{

    if (inventory == null)
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        
    }
}

    private void Update()
    {
        if(inventory == null) 
         Debug.Log("inventory is null");
        else
         Debug.Log("inventory is not null");
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }

    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Spawn>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }
}
