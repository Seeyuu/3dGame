using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movinfplatform : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 5f;

    private Vector3 startPos;
    private float direction = 1f;

    private Rigidbody playerRigidbody; // Reference to the player's Rigidbody

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Move the platform
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        // Check if the platform has reached its maximum distance
        if (Mathf.Abs(transform.position.x - startPos.x) >= distance)
        {
            // Change direction
            direction *= -1;
        }
    }

    void OnCollisionStay(Collision other)
    {
        // Check if the colliding object is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Store a reference to the player's Rigidbody
            playerRigidbody = other.gameObject.GetComponent<Rigidbody>();

            // Make the player a child of the platform
            other.transform.SetParent(transform);
        }
    }

    void OnCollisionExit(Collision other)
    {
        // Check if the colliding object is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Set the player's parent back to null
            other.transform.SetParent(null);

            // Reset the reference to the player's Rigidbody
            playerRigidbody = null;
        }
    }

    void FixedUpdate()
    {
        // If the player is attached to the platform, move the player with the platform
        if (playerRigidbody != null)
        {
            playerRigidbody.MovePosition(playerRigidbody.position + transform.position - startPos);
        }
    }
}
