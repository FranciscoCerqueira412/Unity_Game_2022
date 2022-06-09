using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    private RectTransform interactionRect;
    private RectTransform canvasRect;
    public float MaxRange = 6.75f;
    public string IntText = "Interact!";

    public void Awake()
    {
        interactionRect = GameObject.Find("Interaction Prompt").GetComponent<RectTransform>();
        canvasRect = interactionRect.transform.parent.GetComponent<RectTransform>();
        interactionRect.gameObject.SetActive(false);
    }

    public virtual void OnStartHover()
    {
        interactionRect.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = IntText;
        interactionRect.gameObject.SetActive(true);
        //then you calculate the position of the UI element
        //0,0 for the canvas is at the center of the screen, whereas WorldToViewPortPoint treats the lower left corner as 0,0. Because of this, you need to subtract the height / width of the canvas * 0.5 to get the correct position.

        Vector2 conversion = Camera.main.WorldToViewportPoint(transform.position);
        interactionRect.anchoredPosition = new Vector2(conversion.x + 135f, conversion.y + 60f);

    }

    public virtual void OnInteract() 
    {

    }

    public virtual void OnEndHover() 
    {
        interactionRect.gameObject.SetActive(false);
    }

}