using System;
using UnityEngine;

//Item interface
public interface IItem
{
    string Name { get; }
    Sprite Image { get; }

    void OnPickup();
    void OnDrop();
    void OnHold();
}

//This class allows us to pass the item as an argument when the event is triggered
public class InventoryEventArgs : EventArgs
{
    public IItem Item;

    public InventoryEventArgs(IItem item)
    {
        Item = item;
    }
}