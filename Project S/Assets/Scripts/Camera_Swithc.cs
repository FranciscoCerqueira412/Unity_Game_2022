using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Swithc : MonoBehaviour
{
    public GameObject Main_Camera;
    public GameObject Zoom_Camera;
    public GameObject debugTransformGO;
    ThirdPersonMovement thirdPersonMovement;
    public GameObject Reticle;
    public Transform debugTransform;

    [HideInInspector] public bool zoomed = false;

    [SerializeField]LayerMask aimColliderLayerMask=new LayerMask();

    private void Start()
    {
        thirdPersonMovement = GetComponent<ThirdPersonMovement>();
    }
    public void Update()
    {
        //Saber a posição da mira e virar o player quando este está a mirar//
        Vector3 mouseWorldPosition=Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        if (Physics.Raycast(ray,out RaycastHit raycastHit,999f,aimColliderLayerMask) && Input.GetKey(KeyCode.Mouse1))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }
        zoomed = false;
        if (Input.GetKey(KeyCode.Mouse1))
        {
            zoomed = true;
            Main_Camera.SetActive(false);
            Zoom_Camera.SetActive(true);
            thirdPersonMovement.SetRotateOnMove(false);
            debugTransformGO.SetActive(true);
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;

            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

        }
        ////////////////////////////////////////////////////////////////////////


        else if (!Input.GetKey(KeyCode.Mouse1))
        {
            Zoom_Camera.SetActive(false);
            Main_Camera.SetActive(true);
            thirdPersonMovement.SetRotateOnMove(true);
            debugTransformGO.SetActive(false);
        }

        if (Reticle != null)
            Reticle.SetActive(zoomed);

    }
}
