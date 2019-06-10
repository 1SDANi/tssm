using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller_rigidbody : MonoBehaviour
{
    public string moveY = "Vertical";
    public string moveX = "Horizontal";

    public Vector3 velocity;
    
    public float targetMoveSpeed = 10;
    public float friction = 0.9f;
    public float MoveSpeed { get; private set; }
    public bool Grounded { get; private set; }

    public float Speed;

    private Rigidbody rb;

    private void Start()
	{
		rb = GetComponent<Rigidbody>();
        velocity = Vector3.zero;
        Grounded = false;
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
        Vector3 facing = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized;
        Vector3 siding = Vector3.Cross(facing, Vector3.up);

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
        // Sync movespeed to Time.deltaTime
        MoveSpeed = targetMoveSpeed * (1 - friction * Time.deltaTime);
        if (Grounded)
        {
            if (input != Vector3.zero)
            {
                // Movement speed is slower the greater the difference is between the movement input vector's magnitude
                    //  and it's magnitude in the direction of the player's forward facing vector
                float forwardMagnitude = Mathf.Max(Vector3.Dot(transform.forward, input) / input.magnitude, 0);

                // Add movement to velocity
                velocity += transform.forward.normalized * MoveSpeed * Mathf.Min(forwardMagnitude, 1);
            }

            // Stop if moving incredibly slowly
            if (Mathf.Abs(velocity.magnitude) < 0.001)
            {
                velocity = Vector3.zero;
            }
            else
            {
                // Apply friction
                velocity *= friction * Time.deltaTime;

                // Apply extra friction if the movement vector is pointing behind the player.
                // Friction is greater the greater the smaller the difference is between the movement input vector's magnitude
                    // and the magnitude of the player's forward facing vector
                if (Mathf.Abs(Vector3.Angle(transform.forward, input)) > 90)
                {
                    velocity *= friction * Time.deltaTime * Mathf.Max(Vector3.Dot(-transform.forward, input) / input.magnitude, 0);
                }
            }
        }
	}

    // Because we use Slerp, it's faster to turn 90 degrees with a 135 degree Right-Down input
        // turn than turning 90 degrees with a 90 degree Right input.
        // This creates a tradeoff between turning speed and friction magnitude. 
    private void Turn(Vector3 input)
    {
        if (input != Vector3.zero)
        {
            Vector3 target;
            if (Vector3.Angle(transform.forward, input) == 180)
            {
                // Turn right 179 degrees if the angle between the forward facing vector and the movement input vector is 180 degrees
                target = Vector3.Slerp(transform.forward, Vector3.Slerp(input, transform.right, 0.005f), Time.deltaTime);
            }
            else
            { 
                // Turn towards the movement input vector.
                target = Vector3.Slerp(transform.forward, input, Time.deltaTime);
            }
            Quaternion look = Quaternion.LookRotation(target, Vector3.up);

            rb.MoveRotation(look);
        }
	}
}