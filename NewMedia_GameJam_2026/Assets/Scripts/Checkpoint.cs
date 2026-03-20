using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool activated = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !activated)
        {
            RespawnController.Instance.SetNewRespawnPoint(transform.position);
            activated = true; // Mark as activated to avoid re-triggering
        }
    }
}
