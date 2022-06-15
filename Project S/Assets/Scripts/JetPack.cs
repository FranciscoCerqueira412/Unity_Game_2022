using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class JetPack : MonoBehaviour
{
    public float maxFuel = 60f;
    public float thrustForce = 0.5f;
    public Transform groundedTransform;
    public ParticleSystem effect;

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
        if (Input.GetAxis("Jump") > 0f && curFuel > 0f)
        {
            curFuel -= Time.deltaTime;
            tpc._verticalVelocity= Mathf.Sqrt(thrustForce * 10f );
            effect.Play();
        }
        else if (Physics.Raycast(groundedTransform.position, Vector3.down, 0.05f, LayerMask.GetMask("Ground")) && curFuel < maxFuel)
        {
            curFuel += Time.deltaTime;
            effect.Stop();
        }
        else
        {
            effect.Stop();
        }
    }
}