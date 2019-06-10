using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller_rigidbody : MonoBehaviour
{
    public string moveY = "Vertical";
    public string moveX = "Horizontal";

    public Vector3 velocity;

    public float turningSpeedModifier;
    public float targetMoveSpeed = 10;
    public float friction = 0.9f;
    public float MoveSpeed { get; private set; }
    public bool Grounded { get; private set; }

    public Vector3 facing { get; private set; }
    public Vector3 siding { get; private set; }

    public float Speed;

    private Rigidbody rb;

    public Global global;

    private void Start()
	{
		rb = GetComponent<Rigidbody>();
        velocity = Vector3.zero;
        Grounded = true;
	}

    // Update is called once per frame
    void Update()
    {
        // Get character movement input from the player
        Vector3 moveInput = new Vector3(Input.GetAxis(moveX), 0f, Input.GetAxis(moveY));
        
        // Ignore if input is incredibly small
        if (Mathf.Abs(moveInput.x) < 0.001)
        {
            moveInput.x = 0;
        }
        if (Mathf.Abs(moveInput.z) < 0.001)
        {
            moveInput.z = 0;
        }
        
        // Get direction of camera
        facing = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized;
        siding = Vector3.Cross(facing, Vector3.up);

        // Reorient movement input vector relative to camera 
        moveInput = -siding * moveInput.x + facing * moveInput.z;

        //Handle Movement Input
        ApplyInput(moveInput);

        // Log current speed for debug use. Comment out or remove before release
        Speed = velocity.magnitude;

        // Apply velocity
		rb.MovePosition(transform.position + velocity);
    }
	
	private void ApplyInput(Vector3 input)
    {
        // Handle Turning
        Turn(input);

        // Handle Moving
        Move(input);	
	}
	
	private void Move(Vector3 input)
    {
        // Sync movespeed to global.RefreshDelta
        MoveSpeed = targetMoveSpeed * (1 - friction * global.RefreshDelta);
        if (Grounded)
        {
            if (input != Vector3.zero)
            {
                // Add movement to velocity
                velocity += transform.forward.normalized * MoveSpeed;
            }

            // Stop if moving incredibly slowly
            if (Mathf.Abs(velocity.magnitude) < 0.001)
            {
                velocity = Vector3.zero;
            }
            else
            {
                // Apply friction
                velocity *= friction * global.RefreshDelta;
            }
        }
	}
    
    private void Turn(Vector3 input)
    {
        if (input != Vector3.zero)
        {
            Vector3 target;
            if (Vector3.Angle(transform.forward, input) == 180)
            {
                // Turn right if the angle between the forward facing vector and the movement input vector is 180 degrees
                target = Vector3.Lerp(transform.forward, transform.right, global.RefreshDelta * turningSpeedModifier);
            }
            else
            { 
                // Turn towards the movement input vector.
                target = Vector3.Lerp(transform.forward, input, global.RefreshDelta * turningSpeedModifier);
            }
            Quaternion look = Quaternion.LookRotation(target, Vector3.up);

            rb.MoveRotation(look);
        }
	}
}