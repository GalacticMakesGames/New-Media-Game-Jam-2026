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
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("KeyPlatform"))
        {
            //onKeyPlatform = true;
            gameStateController.isKeybindActive = false; // Disable the keybind
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("KeyPlatform"))
        {
            //onKeyPlatform = false;
            gameStateController.isKeybindActive = true; // Re-enable the keybind
        }
    }
}
