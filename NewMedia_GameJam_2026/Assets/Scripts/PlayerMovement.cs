using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    public float moveSpeed = 5f;
    bool isFacingRight = false;

    Rigidbody2D rb;

    //bool onKeyPlatform = false;
    [SerializeField] GameStateController gameStateController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        FlipSprite();
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

    void FlipSprite()
    {
        if(isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
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
