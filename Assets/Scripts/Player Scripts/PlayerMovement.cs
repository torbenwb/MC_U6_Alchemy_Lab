using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Components 

    Camera mainCamera;
    Rigidbody rigidbody;

    // Fields

    public float moveSpeed = 600.0f;

    // Methods 

    void Awake()
    {
        mainCamera = Camera.main;
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // make sure we have a rigidbody component attached to our player
        if (rigidbody)
        {
            // find out which direction our player wants to go
            Vector3 moveVector = GetMoveVector();

            // here we can override the rigidbody velocity
            // this way we can ignore forces and acceleration
            rigidbody.velocity = moveVector * moveSpeed * Time.fixedDeltaTime;
        }
    }

    // Will use our player's input as well as the camera rotation 
    // to determine which direction we want to move in
    Vector3 GetMoveVector()
    {
        // we'll start by creating the vector we're going to return later
        // if we do this then no matter what happens in the function,
        // we'll be able to return this vector
        Vector3 moveVector = new Vector3();

        // Receive input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Parse input
        // Step 1: use the direction the camera is facing
        // to decide which direction to go

        if (mainCamera)
        {
            // Get the rotation of the main camera in euler angles
            Vector3 cameraRotation = mainCamera.transform.rotation.eulerAngles;

            // remove the pitch and roll
            cameraRotation.x = 0.0f;
            cameraRotation.z = 0.0f;

            // convert rotation to a quaternion
            Quaternion q = Quaternion.Euler(cameraRotation);

            // construct forward and right vectors using our stored input
            Vector3 forward = q * Vector3.forward * moveY;
            Vector3 right = q * Vector3.right * moveX;

            // use forward and right to decide which direction we want to 
            // move our character in
            moveVector = forward + right;

            // normalize our move vector so we don't go faster diagonally than
            // forward and back
            moveVector.Normalize();
        }

        return moveVector;
    }
}
