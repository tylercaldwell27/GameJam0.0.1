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
    public Transform doorUpstairs;
    public Transform doorDownstairs;

    public float repairCoolDownTime = 3f;
    [SerializeField] bool isRepairing = false;
    [SerializeField] bool isNearAWall = false;
    public Transform wall;

    // Custom Keys used to move player
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Up;
    public KeyCode Interact;

    // Players Body
    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wall = GetComponent<Transform>();
        //doorUpstairs = GetComponent<Transform>();
        //doorDownstairs = GetComponent<Transform>();
        
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
                //player goes to 1st floor
                //this.transform.position = doorDownstairs.position;
                Debug.Log("Player is at 2nd Floor Door");
            }
            
            if (atFirstFloorDoor)
            {
                // player goes to 2nd floor
                //this.transform.position = doorUpstairs.position;
                Debug.Log("Player is at 1st Floor Door");
            }

            if(!atFirstFloorDoor)
            {
                Debug.LogWarning("Player is NOT at First Floor door");
            }
            if (!atSecondFloorDoor)
            {
                Debug.LogWarning("Player is NOT at Second Floor door");
            }
            if (!atFirstFloorDoor && !atSecondFloorDoor)
            {
                Debug.LogWarning("Player is NOT at  door");
            }



        }

        // Repair skill
        if (Input.GetKeyDown(Interact))
        {
            // todo check if wall health is full
            if (isNearAWall)
            {
                if (wall.GetComponent<WallHealth>().health < 500 && wall.GetComponent<WallHealth>().health > 0)
                {
                    StartCoroutine("RepairCoolDown");
                    Repair();
                }
            }
            else
            {
                Debug.LogWarning("Not near a wall");
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
        wall.GetComponent<WallHealth>().health = 100.0f;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Wall")
        {
            isNearAWall = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        isNearAWall = false;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "DoorFirstFloor")
        {
            atFirstFloorDoor = true;
        }
        if (col.gameObject.tag == "DoorSecondFloor")
        {
            atSecondFloorDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "DoorFirstFloor")
        {
            atFirstFloorDoor = false;
        }
        if (col.gameObject.tag == "DoorSecondFloor")
        {
            atSecondFloorDoor = false;
        }
    }
}
