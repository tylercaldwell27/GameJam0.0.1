using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControllerRepair : MonoBehaviour
{
    // Movement of the player
    public float moveSpeed;
    [SerializeField] bool atDoorUp;
    [SerializeField] bool atDoorDown;
    public Transform doorUp;
    public Transform doorDown;

    // Keys used to move player
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Up;

    // Players Body
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(Left))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(Right))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey(Up))
        {
            if (atDoorUp)
            {
                // player goes to 1st floor
            }
            if (atDoorDown)
            {
                // player goes to 2nd floor
            }
        }

    }
}
