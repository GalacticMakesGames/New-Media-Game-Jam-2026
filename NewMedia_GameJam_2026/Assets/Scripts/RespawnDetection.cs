using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnDetection : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RespawnController.Instance.RespawnPlayer();
        }
    }
}
