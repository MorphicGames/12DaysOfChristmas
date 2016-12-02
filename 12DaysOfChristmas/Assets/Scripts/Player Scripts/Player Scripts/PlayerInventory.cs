﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {

    private Dictionary<string, Item> inventoryItemList;

	// Use this for initialization
	void Start () {
        inventoryItemList = new Dictionary<string, Item>();
	}

    // Update is called once per frame
    void Update() {

    }

    //Adds New Item to List or if the Item Exists, adds 1 more of it to Item stack
    public void AddItem(string name, Item value)
    {
        Item tmp;
        inventoryItemList.TryGetValue(name, out tmp);
        if (tmp)
        {
            tmp.amount += value.amount;
            inventoryItemList[name] = tmp;
        }
        else
        {
            inventoryItemList.Add(name, value);
        }
    }

    //Removes Existing Item from the Item List, or is the Item has multiple instances stored, removes one count of the instances
    public void RemoveItem(string name)
    {
        Item tmp;
        inventoryItemList.TryGetValue(name, out tmp);
        if (tmp)
        {
            if (tmp.amount - 1 == 0)
            {
                inventoryItemList.Remove(name);
            }
            else
            {
                tmp.amount -= 1;
                inventoryItemList[name] = tmp;
            }
        }
        else
        {
            Debug.Log("Item in Inventory does not Exist, and Error has occured");
        }
    }
}
