using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalInput;
    public float moveSpeed = 5f;
    //bool isFacingRight = false;
    private bool isFacingRight;
    public bool isMoving;
    //private float previousYPosition;

    Rigidbody2D rb;

    private Animator anim;

    //bool onKeyPlatform = false;
    [SerializeField] GameStateController gameStateController;
    [SerializeField] KeyMode keyModeScript;

    public KeyCode moveMode = KeyCode.F;

    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Initialize the previous position to the object's starting position
        //previousYPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        isMoving = rb.velocity.sqrMagnitude > 0.01f; // Using 0.01f to avoid floating point errors

        if (horizontalInput != 0)
        {
            if (gameStateController.isKeyActive == false)
            {
                anim.SetBool("isWalking", true);
                Debug.Log("Walking with a key");
            }
            else
            {
                anim.SetBool("isIdleNoKey", false);
                anim.SetBool("isWalkingNoKey", true);
                Debug.Log("Walking without a key");
            }
        }
        else
        {
            if (gameStateController.isKeyActive == false)
            {
                anim.SetBool("isWalking", false);
                Debug.Log("Walking with a key");
            }
            else
            {
                anim.SetBool("isIdleNoKey", true);
                anim.SetBool("isWalkingNoKey", false);
            }
            //anim.SetBool("isWalking", false);
        }

        //if (horizontalInput != 0)
        //{
        //    anim.SetBool("isWalking", true);
        //    Debug.Log("Walking with a key");
        //}
        //else
        //{
        //    anim.SetBool("isWalking", false);
        //}

        //if (gameStateController.isKeyActive == false)
        //{
        //    anim.SetBool("isWalking", true);
        //    Debug.Log("Walking with a key");
        //}
        //else
        //{
        //    anim.SetBool("isWalkingNoKey", true);
        //}

        //if (horizontalInput != 0)
        //{
        //    if (gameStateController.isKeyActive == false)
        //    {
        //        anim.SetBool("isWalking", true);
        //        Debug.Log("Walking with a key");
        //    }
        //    else
        //    {
        //        anim.SetBool("isWalkingNoKey", true);
        //    }

        //}
        //else
        //{
        //    anim.SetBool("isWalking", false);
        //}

        //else
        //{
        //    if (gameStateController.isKeyActive == false)
        //    {
        //        anim.SetBool("isWalking", false);
        //        anim.SetBool("isIdle", true);
        //    }
        //    else
        //    {
        //        anim.SetBool("isWalkingNoKey", false);
        //        anim.SetBool("isIdleNoKey", true);
        //    }
        //}

        //else if (horizontalInput != 0 && gameStateController.isKeyActive == true)
        //{
        //    anim.SetBool("isWalkingNoKey", true);
        //}
        //else if (horizontalInput == 0 && gameStateController.isKeyActive == true)
        //{
        //    anim.SetBool("isIdleNoKey", true);
        //    anim.SetBool("isWalkingNoKey", false);
        //}

        if (!isFacingRight && horizontalInput > 0)
        {
            Flip();
        }
        else if (isFacingRight && horizontalInput < 0)
        {
            Flip();
        }

        //// Get the current Y position
        //float currentYPosition = transform.position.y;

        //// Check if the current Y position is greater than the previous Y position
        //if (currentYPosition > previousYPosition)
        //{
        //    Debug.Log("Player is moving UP (Y position is increasing).");
        //    anim.SetBool("isClimbing", true);
        //    anim.SetBool("isWalking", false);
        //}
        //else if (currentYPosition < previousYPosition)
        //{
        //    Debug.Log("Player is moving DOWN (Y position is decreasing).");
        //}
        //else
        //{
        //    anim.SetBool("isClimbing", false);
        //}

        //// Update the previous position for the next frame's comparison
        //previousYPosition = currentYPosition;

        //if ((anim.GetBool("isWalkingNoKey") == true | anim.GetBool("isIdleNoKey") == true))
        //{
        //    if (Input.GetKeyDown(moveMode) && gameStateController.isKeybindActive)
        //    {
        //        Debug.Log("Key is Picked Up");
        //        anim.SetBool("isIdleNoKey", false);
        //        anim.SetBool("isPickingUpKey", true);
        //        anim.SetBool("isWalkingNoKey", false);
        //        keyModeScript.keyPlatform.SetActive(false);
        //        gameStateController.isKeyActive = false;
        //    }
        //}

        if ((anim.GetBool("isWalkingNoKey") == true | anim.GetBool("isIdleNoKey") == true))
        {
            if (Input.GetKeyDown(moveMode) && gameStateController.isFKeyPressable)
            {
                Debug.Log("Key is Picked Up");
                anim.SetBool("isIdleNoKey", false);
                anim.SetBool("isPickingUpKey", true);
                anim.SetBool("isWalkingNoKey", false);
                keyModeScript.keyPlatform.SetActive(false);
                gameStateController.isKeyActive = false;
                gameStateController.isFKeyPressable = false;
                gameStateController.isEKeyPressable = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (horizontalInput != 0)
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    // Collisions for not allowing the key to be picked up while you're standing on it
    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("KeyPlatform"))
    //    {
    //        //onKeyPlatform = true;
    //        gameStateController.isKeybindActive = false; // Disable the keybind
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("KeyPlatform"))
    //    {
    //        //onKeyPlatform = false;
    //        gameStateController.isKeybindActive = true; // Re-enable the keybind
    //    }
    //}
}
