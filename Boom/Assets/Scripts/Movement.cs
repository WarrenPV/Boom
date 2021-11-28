using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public float Speed;
    public float speedAerial;
    
    float RBDrag = 6f;
    float verticalMovement;
    float horizontalMovement;
    public float maxVelocity;
    float sqrMaxVelocity;
    Vector3 moveDirection;
    private Rigidbody RB;
    public GroundCheck groundCheck;
    public bool Grounded;
    public int jumpForce;
    private AudioSource audiosource;
    public AudioClip jump;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        SetMaxVelocity();
        RB = GetComponent<Rigidbody>();
        RB.freezeRotation = true;
        groundCheck = GetComponentInChildren<GroundCheck>();
    }
    private void Update()
    {
        playerInput();
        //Drag();
        Grounded = groundCheck.Grounded;
        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            audiosource.PlayOneShot(jump);
            Jump();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
        var v = RB.velocity;
        if (v.sqrMagnitude > sqrMaxVelocity)
        { 
            RB.velocity = v.normalized * maxVelocity;
        }
    }

    void playerInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }

    void MovePlayer()
    {
        if (Grounded)
        {
            RB.AddForce(moveDirection * Speed , ForceMode.Acceleration);
        }
        if (!Grounded)
        {
            RB.AddForce(moveDirection * speedAerial, ForceMode.Acceleration);
        }
        
    }

    void Jump()
    {
        RB.AddForce(transform.up * jumpForce *50);
    }

    void Drag()
    {
        RB.drag = RBDrag;
    }

    void SetMaxVelocity()
    {
        
        sqrMaxVelocity = maxVelocity * maxVelocity;
    }

}
