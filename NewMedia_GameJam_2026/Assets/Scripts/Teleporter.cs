using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // Reference to the destination transform
    public Transform destination;
    [SerializeField] AudioClip teleport;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Teleport the colliding object to the destination's position
            other.transform.position = destination.position;

            AudioSource.PlayClipAtPoint(teleport, transform.position);
        }
    }
}
