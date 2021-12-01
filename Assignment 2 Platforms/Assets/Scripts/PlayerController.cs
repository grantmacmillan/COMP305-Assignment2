using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // "Public" variables
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 500.0f;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;



    // Private Variables
    private Rigidbody2D rBody;
    
    private bool isGrounded = false;
    private bool isFacingRight = true;
    

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        
    }

    // Physics
    private void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        isGrounded = GroundCheck();

        // Jump code goes here!
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            rBody.AddForce(new Vector2(0.0f, jumpForce));
            isGrounded = false;
        }

        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

        // Check if the sprite needs to be flipped
        if ((isFacingRight && rBody.velocity.x < 0) || (!isFacingRight && rBody.velocity.x > 0))
        {
            Flip();
        }
      

        
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);
    }



    private void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;

        isFacingRight = !isFacingRight;
    }


}