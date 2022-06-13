using UnityEngine;
using UnityEngine.UI;

public class ItemClickedHandler : MonoBehaviour
{
    public KeyCode key;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            FadeToColor(button.colors.pressedColor);
            button.onClick.Invoke();
        }
        else if (Input.GetKeyUp(key))
        {
            FadeToColor(button.colors.normalColor);
        }
    }

    void FadeToColor(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, button.colors.fadeDuration, true, true);
    }

    public void OnItemClicked()
    {
        ItemDragHandler dragHandler = transform.GetChild(0).GetComponent<ItemDragHandler>();

        IItem item = dragHandler.item;

        if (item != null)
        {
            item.OnHold();
        }
    }
}
