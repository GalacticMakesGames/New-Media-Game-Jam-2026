using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    // Reference to the player's movement script
    [SerializeField] PlayerMovement playerMovementScript;
    Rigidbody2D rb;

    public bool isPaused = false; // controls the state which pauses player movement and enables mouse input

    public bool isKeybindActive = true; // controls whether the key is pressable
    public KeyCode actionKey = KeyCode.E; // keycode being managed

    // Start is called before the first frame update
    void Start()
    {
        // Lock and hide the cursor during regular gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isKeybindActive && Input.GetKeyDown(actionKey))
        {
            TogglePauseState();
        }
    }

    public void TogglePauseState()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Freeze movement
            if (playerMovementScript != null)
            {
                playerMovementScript.enabled = false; // Disables the entire movement script
                rb.isKinematic = true;
            }

            // Enable mouse cursor
            Cursor.lockState = CursorLockMode.None; // Unlocks the cursor
            Cursor.visible = true; // Makes the cursor visible

        }
        else
        {
            // Re-enable movement
            if (playerMovementScript != null)
            {
                playerMovementScript.enabled = true;
                rb.isKinematic = false;
            }

            // Hide and lock the mouse cursor for resumed gameplay
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }
    }
}
