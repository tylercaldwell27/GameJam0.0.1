using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Movement of the player
    public float moveSpeed;
    public float upforce;
    private bool moving;

    // Keys used to move player
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Up;
    public KeyCode Down;

    // Players Body
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update() {
        if (moving)
        {
            moveSpeed -= Time.deltaTime;
        }


        if (Input.GetKey(Left))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        } else if (Input.GetKey(Right))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        } else {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey(Up))
        {
            rb.velocity = new Vector2(rb.velocity.x, upforce);
        }
        else if (Input.GetKey(Down))
        {
            rb.velocity = new Vector2(rb.velocity.x, -upforce);
        }
        else {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

    }

}
