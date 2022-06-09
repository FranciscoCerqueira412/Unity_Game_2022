using UnityEngine;

public class Skipper : PickUps
{
    public override void Start()
    {
        MaxRange = 6.75f;
        IntText = "Pick Up!";
        objMeshRenderer = GetComponent<MeshRenderer>();
        highlightColor = new Color32(254, 216, 177, 225);
        ogColor = objMeshRenderer.material.color;
    }
}
