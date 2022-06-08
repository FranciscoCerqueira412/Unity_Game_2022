using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public float MaxRange { get { return maxRange; } }

    private const float maxRange = 50f;

    public void OnStartHover()
    {
        Debug.Log("On start hover!");
    }

    public void OnInteract()
    {
        Debug.Log("On interact");
    }

    public void OnEndHover()
    {
        Debug.Log("On EndHover!");
    }
}
