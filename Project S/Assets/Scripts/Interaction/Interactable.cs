using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    //ui stuff
    protected RectTransform interactionRect;
    protected RectTransform canvasRect;
    protected TextMeshProUGUI textMeshPro;
    protected Inventory inventory;

    //public fields
    public float MaxRange = 10f;
    public string IntText = "Interact!";

    public virtual void Awake()
    {
        //interaction UI
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        interactionRect = GameObject.FindGameObjectWithTag("PickableUI").GetComponent<RectTransform>();
        textMeshPro = interactionRect.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        canvasRect = interactionRect.transform.parent.GetComponent<RectTransform>();
    }

    public virtual void Start()
    {
        interactionRect.gameObject.SetActive(false);
    }

    public virtual void OnStartHover()
    {
        ShowInteractableUI();
    }

    public virtual void OnInteract() 
    {

    }

    public virtual void OnEndHover() 
    {
        interactionRect.gameObject.SetActive(false);
    }

    //method to position and show the interactable UI
    public void ShowInteractableUI()
    {
        
        textMeshPro.text = IntText;
        interactionRect.gameObject.SetActive(true);
        //then you calculate the position of the UI element
        //0,0 for the canvas is at the center of the screen, whereas WorldToViewPortPoint treats the lower left corner as 0,0. Because of this, you need to subtract the height / width of the canvas * 0.5 to get the correct position.

        Vector2 conversion = Camera.main.WorldToViewportPoint(transform.position);
        interactionRect.anchoredPosition = new Vector2(conversion.x + 135f, conversion.y + 60f);
    }

}