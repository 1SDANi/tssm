using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controls : MonoBehaviour
{
    public string mouseY = "Mouse Y";
    public string mouseX = "Mouse X";
    public string toggleLock = "Cancel";
    public string scroll = "Mouse ScrollWheel";
    public int horizontalMouseSpeed;
    public int verticalMouseSpeed;
    public int mouseScrollSpeed;

    public bool lockMouse;
    public bool lockUnlocked;
    
    public float maxDistance;
    public float minDistance;
    public float maxVerticalAngle;
    public float minVerticalAngle;

    public Transform follow;
    public Vector3 followOffset;
    public float CameraHeight;
    public float DistanceOffset { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = follow.position + followOffset;
        lockMouse = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = follow.position + followOffset;
        HandleCamera();
    }

    void HandleCamera()
    {
        // Upon pressing the Lock Toggle down, toggle the lock.
        if (Input.GetAxis(toggleLock) > 0)
        {
            if (lockUnlocked)
            {
                lockMouse = !lockMouse;
                lockUnlocked = false;
            }
        }
        else
        {
            lockUnlocked = true;
        }

        // While the mouse is supposed to be locked, lock and hide the mouse and handle camera movement
        if (lockMouse)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Look();
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void Look()
    {
        // Get camera movement input from the player
        Vector3 mouseInput = new Vector3(Input.GetAxis(mouseY), Input.GetAxis(mouseX), Input.GetAxis(scroll));
        
        if (mouseInput.x != 0)
        {
            // Rotate the camera vertically
            Camera.main.transform.Rotate(mouseInput.x * verticalMouseSpeed * Time.deltaTime, 0, 0);
            // Clamp the camera's vertical rotation
            Vector3 cameraRotation = Camera.main.transform.rotation.eulerAngles;
            Camera.main.transform.rotation = Quaternion.Euler(Mathf.Clamp(cameraRotation.x, minVerticalAngle, maxVerticalAngle), cameraRotation.y, cameraRotation.z);
        }

        if (mouseInput.y != 0)
        {
            // Rotate the camera horizontally
            transform.Rotate(0f, mouseInput.y * Time.deltaTime * horizontalMouseSpeed, 0f);
        }

        if (mouseInput.z != 0)
        {
            // Zoom the camera
            DistanceOffset = Mathf.Clamp(DistanceOffset + mouseInput.z * mouseScrollSpeed * Time.deltaTime, minDistance, maxDistance);
            Camera.main.transform.localPosition = new Vector3(0f, CameraHeight, DistanceOffset);
        }
    }
}