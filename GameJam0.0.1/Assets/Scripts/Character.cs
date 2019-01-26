using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Character : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;

    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask isGroundLayer;

    Animator anim;

    //
    public float fallMultiplier = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = 1.0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // stops rotation due to physics
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.sleepMode = RigidbodySleepMode2D.NeverSleep;

        anim = GetComponent<Animator>();

        if (!groundCheck)
        {
            groundCheck = GameObject.Find("GroundCheck").GetComponent<Transform>();
        }
        if (groundCheckRadius <= 0f)
        {
            groundCheckRadius = 0.1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveValue = Input.GetAxisRaw("Horizontal");

        if (groundCheck)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);
        }

        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        else
        {
            anim.SetBool("Grounded", isGrounded);
        }

        if (!isGrounded)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        if (rb)
        {
            rb.velocity = new Vector2(moveValue * speed, rb.velocity.y);
        }

        if (anim)
        {
            anim.SetBool("Grounded", isGrounded);
            anim.SetFloat("Movement", Mathf.Abs(moveValue));
        }
    }
}
