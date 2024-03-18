using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 5f;

    private Vector3 startPos;
    private float direction = 1f;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
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

    private void OnCollisionEnter(Collision other)
    {
        // Check if the colliding object is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Make the player a child of the platform
            other.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        // Check if the colliding object is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Remove the player from being a child of the platform
            other.transform.parent = null;
        }
    }
}
