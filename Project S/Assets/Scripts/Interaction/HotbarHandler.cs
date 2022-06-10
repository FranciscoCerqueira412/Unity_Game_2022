using System;
using UnityEngine;
using UnityEngine.UI;

public class HotbarHandler : PickUps
{
    public void OnEnable()
    {
        inventory.ItemAdded += HotbarAdd;
    }

    public void HotbarAdd(object sender, InventoryEventArgs eventData)
    {
        foreach (Transform slot in transform)
        {
            //get the slot image
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();

            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = eventData.Item.Image;

                break;
            }
        }
    }

    public void OnDisable()
    {
        inventory.ItemAdded -= HotbarAdd;
    }
}
