using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject freeLookCamera;
    CinemachineFreeLook freeLookComponent;
    ThirdPersonMovement playerControllerScript;

    private void Awake()
    {
        freeLookComponent = freeLookCamera.GetComponent<CinemachineFreeLook>();
        playerControllerScript = GetComponent<ThirdPersonMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {

            // use the following line for mouse control of zoom instead of mouse wheel
            // be sure to change Input Axis Name on the Y axis to "Mouse Y"

            //freeLookComponent.m_YAxis.m_MaxSpeed = 10;
            freeLookComponent.m_XAxis.m_MaxSpeed = 500;
            freeLookComponent.m_YAxis.m_MaxSpeed = 10;
        }
        else 
        {
            // use the following line for mouse control of zoom instead of mouse wheel
            // be sure to change Input Axis Name on the Y axis from to "Mouse Y"

            //freeLookComponent.m_YAxis.m_MaxSpeed = 0;
            freeLookComponent.m_XAxis.m_MaxSpeed = 0;
            freeLookComponent.m_YAxis.m_MaxSpeed = 0;
        }


    }
}



