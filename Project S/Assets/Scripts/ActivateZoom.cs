using UnityEngine;

public class ActivateZoom : MonoBehaviour
{
    public KeyCode ActivationKey = KeyCode.Mouse1;
    public int PriorityBoostAmount = 10;
    public GameObject Reticle;
    public Transform ZoomSideAimLookAt;
    public Transform centerPlayerLookAt;


    Cinemachine.CinemachineFreeLook fcam;


    [HideInInspector]public bool zoomed = false;

    void Start()
    {
        fcam = GetComponent<Cinemachine.CinemachineFreeLook>();
    }

    void Update()
    {
        zoomed = false;
        fcam.m_LookAt= ZoomSideAimLookAt;
        fcam.m_Lens.FieldOfView = Mathf.Lerp(fcam.m_Lens.FieldOfView, 40f, .03f);
        if (Input.GetKey(ActivationKey))
        {
            zoomed = true;
            fcam.m_Lens.FieldOfView = Mathf.Lerp(fcam.m_Lens.FieldOfView, 20f, .03f);
            fcam.m_LookAt = ZoomSideAimLookAt;
        }
           

        if (Reticle != null)
            Reticle.SetActive(zoomed);
    }
}
