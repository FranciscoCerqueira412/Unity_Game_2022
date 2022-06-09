using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerpZoom : MonoBehaviour
{
    
    public Transform CenterPlayerLookAt;
    public int interpolationFramesCount = 45;
    int elapsedFrames = 0;

    private void Update()
    {
        //if (Input.GetKey(KeyCode.Mouse1))
        //{
        //    transform.position = Vector3.Lerp(CenterPlayerLookAt.position + new Vector3(0.35f, 0, 0), CenterPlayerLookAt.position, 0.01f+Time.deltaTime);

        //}
        //else
        //    transform.position = Vector3.Lerp(CenterPlayerLookAt.position, CenterPlayerLookAt.position + new Vector3(0.35f, 0, 0), 0.01f*Time.deltaTime);

        //elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);

    //    if (Input.GetKey(KeyCode.Mouse1))
    //    {
    //        Zooming();
    //    }
    //    else
    //        notZoomming();


    }
    //float desiredDuration = 5f;
    //float elapsedTime;

    //private void Zooming()
    //{
    //    elapsedTime += Time.deltaTime;
    //    float percentageComplete = elapsedTime / desiredDuration;
    //    transform.position = Vector3.Lerp(CenterPlayerLookAt.position, CenterPlayerLookAt.position + new Vector3(0.35f, 0, 0), Mathf.SmoothStep(0, 1, percentageComplete));
        
    //}

    //private void notZoomming()
    //{
    //    elapsedTime += Time.deltaTime;
    //    float percentageComplete = elapsedTime / desiredDuration;
    //    transform.position = Vector3.Lerp(CenterPlayerLookAt.position + new Vector3(0.35f, 0, 0), CenterPlayerLookAt.position, Mathf.SmoothStep(0, 1, percentageComplete));
    //}

}
