using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Components //

    Camera mainCamera;

    // Variables //

    // x - pitch
    // y - yaw
    // z - roll
    public Vector3 controlRotation = new Vector3();
    public float pitchTurnRate = 360.0f;
    public float yawTurnRate = 360.0f;

    // Methods //

    void Awake()
    {
        mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Hide and lock the mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Receive input
        float pitchInput = Input.GetAxisRaw("Mouse Y");
        float yawInput = Input.GetAxisRaw("Mouse X");

        // Parse input
        controlRotation.x += -pitchInput * pitchTurnRate * Time.deltaTime;
        controlRotation.y += yawInput * yawTurnRate * Time.deltaTime;

        // Clamp pitch //
        controlRotation.x = Mathf.Clamp(controlRotation.x,-90.0f,90.0f);

        // Rotate Camera //
        if (mainCamera)
        {
            mainCamera.transform.rotation = Quaternion.Euler(controlRotation);
        }
    }   
}
