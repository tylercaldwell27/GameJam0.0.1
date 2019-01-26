
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public float health;
    public float attackDmg;
    public float AttackSpeed = 0.5f;
    Gun gunScript = new Gun();


    public void DeductHealth(float deductHealth)
    {
        health -= deductHealth;
        Debug.Log(health);
        if (health <= 0)
        {

            EnemyDead();
        }
    }

    void EnemyDead()
    {
        Destroy(gameObject);
    }
}