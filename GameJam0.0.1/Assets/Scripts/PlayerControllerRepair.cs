using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControllerRepair : MonoBehaviour
{
    // Movement of the player
    public float moveSpeed = 5.0f;

    [SerializeField] bool atSecondFloorDoor = false;
    [SerializeField] bool atFirstFloorDoor = false;
    [SerializeField] bool atWindow = false;
    public Transform doorUp;
    public Transform doorDown;

    public float repairCoolDownTime = 3f;
    [SerializeField] bool isRepairing = false;
    [SerializeField] bool isNearAWall = false;
    WallHealth wall;

    // Keys used to move player
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Up;
    public KeyCode Interact;

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

        //Input
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
        if (Input.GetKeyDown(Up))
        {
            if (atSecondFloorDoor)
            {
                // player goes to 1st floor
            }
            
            if (atFirstFloorDoor)
            {
                // player goes to 2nd floor
            }

            if(!atFirstFloorDoor || !atSecondFloorDoor)
            {
                Debug.LogWarning("Player is at the door");
            }

        }

        // Repair skill
        if (Input.GetKeyDown(Interact))
        {
            // todo check if wall health is full
            if (isNearAWall)
            {
                if (wall.health < 500 && wall.health > 0)
                {
                    StartCoroutine("RepairCoolDown");
                    Repair();
                }
            }
        }   
    }

    IEnumerator RepairCoolDown()
    {
        isRepairing = true;
        yield return new WaitForSeconds(repairCoolDownTime);
        isRepairing = false;

    }
    void Repair()
    {
        // add health to the wall
        wall.health = 100.0f;
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "Wall")
        {
            isNearAWall = true;
        }
    }
}
