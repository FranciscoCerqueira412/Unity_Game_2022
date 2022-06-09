using UnityEngine;

public class PickUps : Interactable
{
    //vars
    protected Color ogColor;
    protected Color highlightColor;
    protected MeshRenderer objMeshRenderer;

    public virtual void Start()
    {
        objMeshRenderer = GetComponent<MeshRenderer>();
        highlightColor = new Color32(254, 216, 177, 225);
        ogColor = objMeshRenderer.material.color;     
    }

    public override void OnStartHover()
    {
        base.OnStartHover();

        objMeshRenderer.material.color = highlightColor;

        foreach (Transform child in transform)
        {
            child.GetComponent<MeshRenderer>().material.color = highlightColor;
        } 
    }

    public override void OnInteract()
    {
        Debug.Log("Picked up !" + transform.name);
        gameObject.SetActive(false);
    }

    public override void OnEndHover()
    {
        base.OnEndHover();
        objMeshRenderer.material.color = ogColor;

        foreach (Transform child in transform)
        {
            child.GetComponent<MeshRenderer>().material.color = ogColor;
        }
    }
}
