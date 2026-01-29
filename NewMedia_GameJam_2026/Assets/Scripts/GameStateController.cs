using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    // Reference to the player's movement script
    [SerializeField] PlayerMovement playerMovementScript;
    [SerializeField] KeyMode keyModeScript;
    PlayerMovement moveSpeed;
    Rigidbody2D rb;
    private Animator anim;

    public bool isPaused = false; // controls the state which pauses player movement and enables mouse input

    public bool isKeybindActive = true; // controls whether the key is pressable
    public bool isEKeyPressable = true;
    public bool isFKeyPressable = false;
    public KeyCode keyMode = KeyCode.E;
    //public KeyCode moveMode = KeyCode.F;

    public bool isKeyActive = false;

    // Start is called before the first frame update
    void Start()
    {
        // Lock and hide the cursor during regular gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (isKeybindActive && Input.GetKeyDown(keyMode))
        //{
        //    if (playerMovementScript.isMoving)
        //    {
        //        rb.velocity = new Vector2(0, rb.velocity.y);
        //        anim.SetBool("isWalking", false);
        //    }
        //    isKeyActive = true;
        //    TogglePauseState();
        //}

        if (isEKeyPressable && Input.GetKeyDown(keyMode))
        {
            if (playerMovementScript.isMoving)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                anim.SetBool("isWalking", false);
            }
            isKeyActive = true;
            TogglePauseState();
        }

        //if (isPaused && Input.GetKeyDown(moveMode))
        //{
        //    Debug.Log("F pressed, confirmed key placement");

        //    anim.SetBool("isKeyMode", false);
        //    anim.SetBool("isIdleNoKey", true);
        //    // Re-enable movement
        //    if (playerMovementScript != null)
        //    {
        //        playerMovementScript.enabled = true;
        //        rb.isKinematic = false;
        //    }

        //    // Hide and lock the mouse cursor for resumed gameplay
        //    Cursor.lockState = CursorLockMode.Locked;
        //    Cursor.visible = false;

        //    keyModeScript.keyPlatform.SetActive(false);
        //}
    }

    public void TogglePauseState()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            anim.SetBool("isKeyMode", true);
            Debug.Log("Key Mode active");
            // Freeze movement
            if (playerMovementScript != null)
            {
                rb.isKinematic = true;
                playerMovementScript.enabled = false; // Disables the entire movement script
            }

            // Enable mouse cursor
            Cursor.lockState = CursorLockMode.None; // Unlocks the cursor
            Cursor.visible = true; // Makes the cursor visible
        }
        else
        {
            //isKeyActive = false;
            anim.SetBool("isKeyMode", false);
            Debug.Log("Key Mode inactive");
            anim.SetBool("isIdleNoKey", true);
            //anim.SetBool("isWalkingNoKey", true);

            // Re-enable movement
            if (playerMovementScript != null)
            {
                playerMovementScript.enabled = true;
                rb.isKinematic = false;
            }

            // Hide and lock the mouse cursor for resumed gameplay
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isEKeyPressable = false;
            isFKeyPressable = true;
}

        //else if (isPaused && Input.GetKeyDown(KeyCode.R))
        //{
        //    anim.SetBool("isKeyMode", false);
        //    // Re-enable movement
        //    if (playerMovementScript != null)
        //    {
        //        playerMovementScript.enabled = true;
        //        rb.isKinematic = false;
        //    }

        //    // Hide and lock the mouse cursor for resumed gameplay
        //    Cursor.lockState = CursorLockMode.Locked;
        //    Cursor.visible = false;
        //}

        //else if (isPaused && Input.GetKeyDown(moveMode))
        //{
        //    anim.SetBool("isKeyMode", false);
        //    anim.SetBool("isIdleNoKey", true);
        //    // Re-enable movement
        //    if (playerMovementScript != null)
        //    {
        //        playerMovementScript.enabled = true;
        //        rb.isKinematic = false;
        //    }

        //    // Hide and lock the mouse cursor for resumed gameplay
        //    Cursor.lockState = CursorLockMode.Locked;
        //    Cursor.visible = false;
        //}

    }
}
