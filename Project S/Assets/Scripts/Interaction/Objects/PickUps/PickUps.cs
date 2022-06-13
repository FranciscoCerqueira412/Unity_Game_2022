using UnityEngine;

//this class defines the interaction and the behaviour of all the Pickable Items
public class PickUps : Interactable
{
    //vars
    protected Color ogColor;
    protected Color highlightColor;
    protected MeshRenderer objMeshRenderer;

    public override void OnStartHover()
    {
        base.OnStartHover();

        ChangeInteractableColor(highlightColor);
    }

    public override void OnInteract()
    {
        inventory.AddItem(gameObject.GetComponent<IItem>());
    }

    public override void OnEndHover()
    {
        base.OnEndHover();

        ChangeInteractableColor(ogColor);
    }

    //color animation method
    public void ChangeInteractableColor(Color color) 
    {
        objMeshRenderer.material.color = color;

        foreach (Transform child in transform)
        {
            child.GetComponent<MeshRenderer>().material.color = color;
        }
    }
}
