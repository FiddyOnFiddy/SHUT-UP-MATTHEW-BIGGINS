using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public PhysicsMaterial2D slide;
    public PhysicsMaterial2D notSlide;
    public BoxCollider2D bc;


    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public float jumpSpeed = 13.0f;
    public float movementSpeed = 8.0f;

    public bool isGrounded = true;


	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = gameObject.GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update ()
    {
        Movement();

        Jump();


    }

    void Movement()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.velocity = new Vector2(movementSpeed * Time.fixedDeltaTime * 10.0f, rb.velocity.y);

        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-movementSpeed * Time.fixedDeltaTime * 10.0f, rb.velocity.y);
            

        }
        else
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }

    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") & isGrounded)
        {
            isGrounded = false;
            rb.velocity = Vector2.up * jumpSpeed;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;

        }
    }
}
