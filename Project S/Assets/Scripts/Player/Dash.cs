using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class Dash : MonoBehaviour
{
    ThirdPersonControllerCustom thirdReference;
    StarterAssetsInputsCustom _input;

    [SerializeField] TrailRenderer tr;
    private bool canDash = true;
    private bool isDashing;
    public float dashSpeed;
    public float dashTime;

    public float dashCooldown;
    public float dashCooldownTimer;

    Animator _anim;

    private void Start()
    {
        thirdReference = GetComponent<ThirdPersonControllerCustom>();
        _input= GetComponent<StarterAssetsInputsCustom>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (dashCooldownTimer>0)
        {
            dashCooldownTimer -= Time.deltaTime;
        }
        if (dashCooldownTimer<0)
        {
            dashCooldownTimer = 0;
        }

        _anim.SetBool("Dash", false);
        if (_input.dash && dashCooldownTimer==0)
        {
            _anim.SetBool("Dash", true);
            StartCoroutine(Dashh());
            dashCooldownTimer = dashCooldown;
        }
    }

    IEnumerator Dashh()
    {
        canDash = false;
        isDashing = true;
        thirdReference.Walk(dashSpeed);
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        thirdReference.Walk(1);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

    }


}
