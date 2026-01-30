using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Teleporter : MonoBehaviour
{
    // Reference to the destination transform
    public Transform destination;
    [SerializeField] AudioClip teleport;
    public float bearScale = .01f;
    public Transform targetTransform;
    public GameObject targetObject;
    public CinemachineVirtualCamera vcam;
    public float cineZoom = .01f;

    private void Start()
    {

        targetObject = GameObject.Find("Player");
        if (targetObject != null)
        {
            targetTransform = targetObject.transform;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Teleport the colliding object to the destination's position
            other.transform.position = destination.position;

            AudioSource.PlayClipAtPoint(teleport, transform.position);

            targetTransform.localScale = new Vector3(bearScale, bearScale, bearScale);

            vcam.m_Lens.OrthographicSize = cineZoom;

        }
    }
}
