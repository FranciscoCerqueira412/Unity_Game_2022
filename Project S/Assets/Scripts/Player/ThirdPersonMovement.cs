using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [Header("Character")]
    public CharacterController controller;
    public Animator anim;

    [Header("Character Stats")]
    public float speed;
    public float runningSpeed; 
    public float gravity;
    public float jumpHeight;
    public float groundDistance ;
    public float turnSmoothTime ;
    public float turnSmoothVelocity;
    Vector3 velocity;
    bool isGrounded;
    bool _rotateOnMove=true;
    public Transform groundCheck;
    public LayerMask groundMask;

    [Header("Camera")]
    public Transform cameraObjTransform;




    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Dance();

        Jump();

        Gravity();

        Walk();         

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
    public void Jump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            anim.SetTrigger("isJumping");
            anim.SetBool("isInAir", true);

        }
        if (isGrounded == true)
        {
            anim.SetBool("isInAir", false);
        }
    }
    public void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    public void Walk()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (horizontal != 0 && vertical != 0 || horizontal != 0 && vertical == 0 || horizontal == 0 && vertical != 0)
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


                transform.rotation = Quaternion.Euler(0f, cameraObjTransform.eulerAngles.y, 0f);

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
    }

}