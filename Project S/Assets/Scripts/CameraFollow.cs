using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject freeLookCamera;
    [SerializeField] GameObject virtualCamera;

    CinemachineFreeLook freeLookComponent;
    CinemachineVirtualCamera virtualLookComponent;
    ThirdPersonMovement playerControllerScript;

    private void Awake()
    {
        freeLookComponent = freeLookCamera.GetComponent<CinemachineFreeLook>();
        virtualLookComponent = virtualCamera.GetComponent<CinemachineVirtualCamera>();
        playerControllerScript = GetComponent<ThirdPersonMovement>();

    }

    private void Update()
    {
        if (Input.GetMouseButton(0)||Input.GetMouseButton(1))
        {
            freeLookComponent.m_XAxis.m_MaxSpeed = 500;
            freeLookComponent.m_YAxis.m_MaxSpeed = 10;

        }
        else
        {
            freeLookComponent.m_XAxis.m_MaxSpeed = 0;
            freeLookComponent.m_YAxis.m_MaxSpeed = 0;
        }






    }
}









