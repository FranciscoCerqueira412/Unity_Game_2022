using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : PickUps, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform hotbar = transform as RectTransform;

        if (!RectTransformUtility.RectangleContainsScreenPoint(hotbar, Input.mousePosition))
        {
            IItem item = eventData.pointerDrag.GetComponent<ItemDragHandler>().item;

            if (item != null)
            {
                inventory.RemoveItem(item);
            }
        }
    }
}
