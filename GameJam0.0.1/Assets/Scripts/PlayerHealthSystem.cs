using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    public float health;
    public float NextHit = 0.0f;
    public bool attacked = false;
    public float lives = 4;
    public EnemyHealthSystem enemy;


    //public float AttackSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning("Health = " + health);
    }

    // Update is called once per frame
    void Update()
    {
        if (attacked)
        {
            TakeDamage();
            Debug.Log(health);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {

        // if the player has hit the enemy
        if (other.gameObject.tag == "Generic")
        {
            attacked = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {

        // if the player has hit the enemy
        if (other.gameObject.tag == "Generic")
        {
            attacked = false;
        }
    }

    public void TakeDamage()
    {
        if (Time.time > NextHit)
        {
            NextHit = Time.time + enemy.AttackSpeed;
            int damagePlayer = 10;// the ammont of damge the enemy does to the player
            health = health - damagePlayer;//subtracts the amoutn of damage done from the players health
        }
    }
}