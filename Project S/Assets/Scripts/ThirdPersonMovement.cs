using System.Collections;


using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;

    public float speed ;
    public float runningSpeed; 
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    Vector3 velocity;
    bool isGrounded;
    bool _rotateOnMove=true;

    public Camera cameraObj;
    public Transform cameraObjTransform;
    public float camSpeed = 2f;



    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        anim.SetBool("isWalking", false);
    }
    // Update is called once per frame
    void Update()
    {
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

        }


        Dance();


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            anim.SetTrigger("isJumping");
            anim.SetBool("isInAir", true);

        }
        if (isGrounded==true)
        {
            anim.SetBool("isInAir", false);
        }
        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (horizontal !=0 && vertical != 0 || horizontal != 0 && vertical == 0 || horizontal == 0 && vertical != 0 )
        {
            anim.SetBool("isWalking", true);
        }
        else
            anim.SetBool("isWalking", false);




        if (direction.magnitude >= 0.1f)
        {
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraObjTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            if (_rotateOnMove)
            {
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }
            

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = runningSpeed;
                anim.SetBool("isRunning", true);
            }
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("isRunning", false);
                speed = 3;
            }

                

        }

        //debug
        if (Input.GetKeyDown(KeyCode.I))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyUp(KeyCode.I))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

    }
    public void SetRotateOnMove(bool newRotateOnMove)
    {
        _rotateOnMove = newRotateOnMove;
    }

    public void Dance()
    {
        float randomNumber = Random.Range(1, 3);
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            anim.SetTrigger("Dance" + randomNumber);
        }
    }

}