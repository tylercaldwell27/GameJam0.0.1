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
    public Sprite SecondLive;
    public Sprite ThirdLive;
    public Sprite ForthLive;
    private SpriteRenderer RenderSprite;
    public Transform RespawnPoint;


    //public float AttackSpeed;

    // Start is called before the first frame update
    void Start()
    {
        RenderSprite = GetComponent<SpriteRenderer>();
        Debug.LogWarning("Health = " + health);
        RespawnPoint = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attacked && this.health > 0.0f)
        {
            TakeDamage();
            Debug.Log(health);
        }
        else if (this.health <= 0 && lives >=1)
        {
            //  this.gameObject.SetActive(false);

            this.transform.position = RespawnPoint.transform.position;
            lives = lives - 1;
            ChangeSprite();
            health = 100;
            Debug.Log("lives remaining: " + lives);
          //  this.gameObject.SetActive(true);

            //teleport to respawn
            //change sprite
            // set active to false
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
            health = health - enemy.attackDmg;//subtracts the amoutn of damage done from the players health
        }
    }

    void ChangeSprite()
    {
        if (lives == 3)
        {
            RenderSprite.sprite = SecondLive;
        }
        if (lives == 2)
        {
            RenderSprite.sprite = ThirdLive;
        }
        if (lives == 1)
        {
            RenderSprite.sprite = ForthLive;
        }
    }
}