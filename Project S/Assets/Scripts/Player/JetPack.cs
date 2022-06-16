using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class JetPack : MonoBehaviour
{
    public float maxFuel = 60f;
    public float thrustForce = 0.5f;
    public Transform groundedTransform;
    public ParticleSystem[] effect;


    ThirdPersonControllerCustom tpc;

    private float curFuel;

    // Start is called before the first frame update
    void Start()
    {
        curFuel = maxFuel;
        tpc = FindObjectOfType<ThirdPersonControllerCustom>();

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(curFuel);
        
        if (Input.GetKey(KeyCode.Space) && curFuel > 0f)
        {
            curFuel -= Time.deltaTime;
            tpc._verticalVelocity= Mathf.Sqrt(thrustForce * 10f );
            effect[0].Play();
            effect[1].Play();
        }
        else if (Physics.Raycast(groundedTransform.position, Vector3.down, 0.05f, LayerMask.GetMask("Ground")) && curFuel < maxFuel)
        {
            curFuel += Time.deltaTime;
            effect[0].Stop();
        }
        else
        {
            effect[0].Stop();
            effect[1].Stop();
        }
    }
}