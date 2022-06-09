using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    private Interactable currentTarget;
    private Camera mainCamera;
    public RaycastHit hit;

    private void Start()
    {
        mainCamera = Camera.main;        
    }

    private void Update()
    {
        RaycastInteractable();      

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTarget != null)
            {
                currentTarget.OnInteract();
            }
        }
    }

    public void RaycastInteractable()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 15.0f, Color.red, 2f);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                if (hit.distance <= interactable.MaxRange)
                {
                    if (interactable == currentTarget)
                    {
                        return;
                    }
                    else if (currentTarget != null)
                    {
                        currentTarget.OnEndHover();
                        currentTarget = interactable;
                        currentTarget.OnStartHover();
                        return;
                    }
                    else
                    {
                        currentTarget = interactable;
                        currentTarget.OnStartHover();
                        return;
                    }
                }
                else
                {
                    if (currentTarget != null)
                    {
                        currentTarget.OnEndHover();
                        currentTarget = null;
                        return;
                    }
                }
            }
            else
            {
                if (currentTarget != null)
                {
                    currentTarget.OnEndHover();
                    currentTarget = null;
                    return;
                }
            }
        }
        else
        {
            if (currentTarget != null)
            {
                currentTarget.OnEndHover();
                currentTarget = null;
                return;
            }
        }
    }
}
