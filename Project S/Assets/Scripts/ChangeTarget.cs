using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTarget : MonoBehaviour
{

    public Transform target;
    public float speed = 1f;

    int randomTarget;
    Quaternion newRot;
    Vector3 relPos;

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        else
        {
            relPos = target.position - transform.position;
            newRot = Quaternion.LookRotation(relPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRot, Time.time * speed);
        }
    }

   
}