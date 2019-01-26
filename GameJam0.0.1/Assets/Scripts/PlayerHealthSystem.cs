using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    public float health;
    public float NextHit = 0.0f;
    //public float AttackSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning("Health = " + health);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay(Collision other)
    {

        // if the player has hit the enemy
        if (other.gameObject.tag == "Default")
        {
            if (Time.time > NextHit)
            {

                NextHit = Time.time + 1;
                int damagePlayer = 10;// the ammont of damge the enemy does to the player
                health = health - damagePlayer;//subtracts the amoutn of damage done from the players health
                                               // Debug.Log(health);// prints the remaining health to the screen.
                Debug.LogWarning("Health = " + health);


            }
        }
    }
}