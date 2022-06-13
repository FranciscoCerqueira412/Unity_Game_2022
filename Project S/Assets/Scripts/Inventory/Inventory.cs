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

            //fetch items collider
            Collider itemCollider = (item as MonoBehaviour).gameObject.GetComponent<Collider>();
            //disable item collider on PickUp (re-enable on drop later)
            itemCollider.enabled = false;

            //? - checks if event is null
            ItemAdded?.Invoke(this, new InventoryEventArgs(item));
        }
    }

    public void RemoveItem(IItem item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);

            item.OnDrop();

            Collider itemCollider = (item as MonoBehaviour ).gameObject.GetComponent<Collider>();
            
            if (itemCollider != null && !itemCollider.enabled)
            {
                itemCollider.enabled = true;
            }

            ItemRemoved?.Invoke(this, new InventoryEventArgs(item));
        }
    }


}
