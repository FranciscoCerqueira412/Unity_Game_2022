using System;
using UnityEngine;
using UnityEngine.UI;

public class HotbarHandler : PickUps
{
    public void OnEnable()
    {
        inventory.ItemAdded += HotbarAdd;
        inventory.ItemRemoved += HotbarRemove;
    }

    public void HotbarAdd(object sender, InventoryEventArgs eventData)
    {
        foreach (Transform slot in transform)
        {
            //get the slot image
            Transform imgTransform = slot.GetChild(0).GetChild(0);
            Image image = imgTransform.GetComponent<Image>();
            ItemDragHandler dragHandler = imgTransform.GetComponent<ItemDragHandler>();

            //empty slot
            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = eventData.Item.Image;

                //store reference to item
                dragHandler.item = eventData.Item;

                break;
            }
        }
    }

    private void HotbarRemove(object sender, InventoryEventArgs eventData)
    {
        Debug.Log(transform.childCount);
        foreach (Transform slot in transform)
        {
          
            Transform imgTransform = slot.GetChild(0).GetChild(0);
            IItem item = imgTransform.GetComponent<IItem>();
            Image image = imgTransform.GetComponent<Image>();
            if (!image.enabled)
            {
                continue;
            }
            ItemDragHandler dragHandler = imgTransform.GetComponent<ItemDragHandler>();

            //if item found in the UI
            if (dragHandler.item.Equals(eventData.Item))
            {
                image.enabled = false;
                image.sprite = null;
                dragHandler.item = null;

                //checks if the item has any parent (is in holster or in the player's back)
                GameObject go = (eventData.Item as MonoBehaviour).gameObject;
                if (go.transform.parent != null)
                {
                    go.transform.parent = null;
                }

                return;
            }
        }
    }



    public void OnDisable()
    {
        inventory.ItemAdded -= HotbarAdd;
        inventory.ItemRemoved -= HotbarRemove;
    }
}
