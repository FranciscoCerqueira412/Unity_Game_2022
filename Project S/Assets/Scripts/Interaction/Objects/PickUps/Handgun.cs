using UnityEngine;

public class Handgun : PickUps, IItem
{
    //fields
    public string Name => "Handgun";

    public Sprite _Image;

    public Sprite Image => _Image;
    //

    //on interact callback
    public override void OnInteract()
    {
        base.OnInteract();
        Debug.Log("worked :)");
    }


    //item callbacks
    public void OnDrop()
    {
        Debug.Log("OnDrop");
    }

    public void OnHold()
    {
        Debug.Log("OnHold");
    }

    public void OnPickup()
    {
        Debug.Log("OnPickup");
    }

    //
    public override void Start()
    {
        objMeshRenderer = GetComponent<MeshRenderer>();
        highlightColor = new Color32(254, 216, 177, 225);
        ogColor = objMeshRenderer.material.color;
    }
}
