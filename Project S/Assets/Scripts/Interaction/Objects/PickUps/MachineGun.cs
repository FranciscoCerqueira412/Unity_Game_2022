using UnityEngine;

public class MachineGun : PickUps, IItem
{
    //fields
    public string Name => "MachineGun";

    public Sprite _Image;

    public Sprite Image => _Image;
    //
    Weapons machinegun;

    //pickup fields
    public GameObject backHolster;
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
        if (transform.gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
            machinegun.rigBuilder.layers[6].active = false;
            machinegun._weapons[1].gameObject.SetActive(false);
        }
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
        if (backHolster.transform.childCount == 0)
        {
            transform.parent = backHolster.transform;
            transform.localPosition = pickPosition;
            transform.localEulerAngles = pickRotation;
        }
    }

    //
    public override void Start()
    {
        machinegun = FindObjectOfType<Weapons>();
        objMeshRenderer = GetComponent<MeshRenderer>();
        highlightColor = new Color32(254, 216, 177, 225);
        ogColor = objMeshRenderer.material.color;
        defaultRotation = transform.rotation;
        defaultScale = transform.lossyScale / 10;

        IntText = "Pick Up!";
        Debug.Log("MachineGun start!");
    }
}
