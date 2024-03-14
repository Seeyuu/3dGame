using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movinfplatform : MonoBehaviour
{
    public float moveDistance = 5f; // Total distance platform should move
    public float moveSpeed = 2f; // Speed of movement

    private Vector3 startPos;
    private float direction = 1f; // Initial direction of movement

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.PingPong(Time.time * moveSpeed, moveDistance) + startPos.x;
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
    }
}
