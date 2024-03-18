using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Move the player object to the specified position
            other.transform.position = new Vector3(-0.05026536f, 0.3435564f, -0.2365819f);
        }
    }
}
