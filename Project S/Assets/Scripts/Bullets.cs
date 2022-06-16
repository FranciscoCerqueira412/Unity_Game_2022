using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private Rigidbody bulletRB;
    public bool useGravity = true;

    private void Awake()
    {
        bulletRB = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 65f;
        bulletRB.velocity = transform.forward * speed;

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        bulletRB.useGravity = false;
        if (useGravity) bulletRB.AddForce(Physics.gravity * (bulletRB.mass * bulletRB.mass));
    }
}
