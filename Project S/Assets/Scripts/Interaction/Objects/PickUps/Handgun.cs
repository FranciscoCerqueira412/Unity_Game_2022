using UnityEngine;

public class Handgun : PickUps, IItem
{
    //fields
    public string Name => "Handgun";

    public Sprite _Image;

    public Sprite Image => _Image;
    //

    //pickup fields
    public GameObject holster;
    public Vector3 pickPosition;
    public Vector3 pickRotation;

    private Vector3 defaultScale { get; set; }
    private Quaternion defaultRotation;

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
        transform.SetPositionAndRotation(player.transform.position + new Vector3(0, 0, 0.5f), defaultRotation);
        transform.localScale = defaultScale;
    }

    public void OnHold()
    {
        Debug.Log("OnHold");
    }

    public void OnPickup()
    {
        if (holster.transform.childCount == 0)
        {
            transform.parent = holster.transform;
            transform.localPosition = pickPosition;
            transform.localEulerAngles = pickRotation;
        }
    }

    //
    public override void Start()
    {
        objMeshRenderer = GetComponent<MeshRenderer>();
        highlightColor = new Color32(254, 216, 177, 225);
        ogColor = objMeshRenderer.material.color;
        defaultRotation = transform.rotation;
        defaultScale = transform.lossyScale;

        IntText = "PickUp!";
        Debug.Log("Handgun Start!");
    }
}
