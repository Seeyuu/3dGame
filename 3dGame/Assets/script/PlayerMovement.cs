using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;


public class PlayerMovement : NetworkBehaviour
{
    [Header("Movement")]
    public float movementSpeed;
    public float jumpForce;
    public Transform movementOrientation;

    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;

    [Header("Third Person Camera")]
    public Transform cameraOrientation;
    public Transform playerObj;
    public float rotationSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }

    private void Update()
    {
        MyInput();
        SpeedControl();
        UpdateThirdPersonCamera();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        if (!IsOwner) return;
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void MovePlayer()
    {

        if (!IsOwner) return;
        moveDirection = movementOrientation.forward * verticalInput + movementOrientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * movementSpeed * 10f, ForceMode.Force);
    }

    private void Jump()
    {

        if (!IsOwner) return;
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        float distanceT0Ground = 0.1f;
        RaycastHit hit;
        return Physics.Raycast(transform.position, -Vector3.up, out hit, distanceT0Ground);
    }

    private void SpeedControl()
    {

        if (!IsOwner) return;
        Vector3 flatvel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatvel.magnitude > movementSpeed)
        {
            Vector3 limitedVel = flatvel.normalized * movementSpeed;
            rb.velocity = new Vector3(limitedVel.x, limitedVel.y, limitedVel.z);
        }
    }

    private void UpdateThirdPersonCamera()
    {

        if (!IsOwner) return;
        Vector3 viewDir = playerObj.position - new Vector3(cameraOrientation.position.x, playerObj.position.y, cameraOrientation.position.z);
        cameraOrientation.forward = viewDir.normalized;

        Vector3 inputDir = cameraOrientation.forward * verticalInput + cameraOrientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
    }
}
