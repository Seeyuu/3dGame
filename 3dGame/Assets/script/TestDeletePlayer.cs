using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDeletePlayer : MonoBehaviour
{
    public GameObject player;

    public void OnButtonClick()
    {
        player.SetActive(false);
    }
}
