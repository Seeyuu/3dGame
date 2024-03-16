using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverZone : MonoBehaviour
{
    public GameObject Player;
    public Transform StartPosition;

    private void OnTriggerEnter(Collider other)
    {
        Player.transform.position = new Vector3(-0.05026536f, 0.3435564f, -0.2365819f);

    }
}
