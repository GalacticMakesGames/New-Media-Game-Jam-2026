using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMode : MonoBehaviour
{
    [SerializeField] GameStateController gameStateController;
    public GameObject keyPlatform;

    Vector3 pos;
    float keySpeed = 1f;
    public Vector3 targetRotation = new Vector3(0, 0, 150);

    public float rotationStep = 15f; // Amount to rotate per click (in degrees)

    // Start is called before the first frame update
    void Start()
    {
        keyPlatform.SetActive(false);
        transform.eulerAngles = targetRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStateController.isPaused)
        {
            FollowMouse();
        }

        // Left Mouse Click (Clockwise)
        if (Input.GetMouseButtonDown(0)) // left mouse button click
        {
            //RotateObject();
            transform.Rotate(Vector3.forward, -rotationStep);
        }

        // Right Mouse Click (Counter-clockwise)
        if (Input.GetMouseButtonDown(1)) // right mouse button click
        {
            //RotateObject();
            transform.Rotate(Vector3.forward, rotationStep);
        }
    }

    public void FollowMouse()
    {
        keyPlatform.SetActive(true);

        pos = Input.mousePosition;
        pos.z = keySpeed;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }

    //void RotateObject()
    //{
    //    // Calculate the new target rotation (current + step)
    //    targetRotation = transform.rotation.eulerAngles.z + rotationStep;
    //    transform.Rotate(Vector3.forward, rotationStep, Space.Self); // Rotate relative to self
    //}
}
