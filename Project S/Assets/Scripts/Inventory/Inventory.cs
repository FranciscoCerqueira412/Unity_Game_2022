using System;
using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    private const int slots = 3;

    private List<IItem> items = new List<IItem>();

    //events to update UI
    public event EventHandler<InventoryEventArgs> ItemAdded;
    //public event EventHandler<InventoryEventArgs> ItemRemoved;
    //public event EventHandler<InventoryEventArgs> ItemHeld;

    public void AddItem(IItem item)
    {
        if (items.Count < slots)
        {
            items.Add(item);

            item.OnPickup();

            //? - checks if event is null
            ItemAdded?.Invoke(this, new InventoryEventArgs(item));
        }
    }


}
