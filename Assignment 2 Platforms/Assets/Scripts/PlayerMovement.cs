using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1;
    public float jumpForce = 1;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * moveSpeed;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

    }
}
