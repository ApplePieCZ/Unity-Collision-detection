// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for FPS player movement

using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Key binds")]
    public KeyCode jumpKey = KeyCode.Space;

    public KeyCode sprintKey = KeyCode.LeftShift;

    public KeyCode crouchKey = KeyCode.C;
    
    [Header("Text")]
    public TextMeshProUGUI[] text;
    
    [Header("Movement")]
    
    private float moveSpeed;

    public float walkSpeed;
    
    public float sprintSpeed;

    public float wallRunSpeed;
    
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    
    private bool readyToJump;

    [Header("Crouching")] 
    public float crouchSpeed;

    public float crouchYScale;
    
    private float startYScale;
    
    [Header("Ground Check")]
    
    public float groundDrag;
    
    public float playerHeight;
    
    private float horizontalInput;

    private float verticalInput;

    private Vector3 moveDirection;

    private Rigidbody rb;
    
    public LayerMask whatIsGround;

    [HideInInspector] public bool grounded;
    public bool wallRunning;
    public Transform orientation;

    public MovementState state;
    public enum MovementState
    {
        Walking,
        Sprinting,
        Crouching,
        WallRunning,
        Air,
    }
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        startYScale = transform.localScale.y;

        readyToJump = true;
    }
    
    private void Update()
    {
        grounded = Physics.Raycast(transform.position, 
                                   Vector3.down, 
                                   playerHeight * 0.5f + 0.2f, 
                                   whatIsGround);
        MyInput();
        SpeedControl();
        StateHandler();

        text[0].text = "Grounded: " + grounded;
        text[1].text = "Jump: " + readyToJump;
        text[2].text = "Wall running: " + wallRunning;

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }

        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }
        
        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void StateHandler()
    {
        if (wallRunning)
        {
            state = MovementState.WallRunning;
            moveSpeed = wallRunSpeed;
        }
        else if (grounded && Input.GetKey(crouchKey))
        {
            state = MovementState.Crouching;
            moveSpeed = crouchSpeed;
        }
        else if (grounded && Input.GetKey(sprintKey))
        {
            state = MovementState.Sprinting;
            moveSpeed = sprintSpeed;
        }
        else if (grounded)
        {
            state = MovementState.Walking;
            moveSpeed = walkSpeed;
        }
        else
        {
            state = MovementState.Air;
        }
    }
   
}
