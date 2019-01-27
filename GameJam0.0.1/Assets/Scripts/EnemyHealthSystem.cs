
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public float health;
    public float currentHealth;
    public float attackDmg;
    public float AttackSpeed;

    [SerializeField]
    private float flashLength;

    private float flashCounter;

    private Renderer renderer;
    private Color defaultColor;

    void Start()
    {
        currentHealth = health;
        renderer = GetComponent<Renderer>();
        defaultColor = renderer.material.GetColor("_Color");
    }

    void Update()
    {
        if (health <= 0)
        {

            EnemyDead();
        }


        if (flashCounter > 0.0f)
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0.0f)
            {
                renderer.material.SetColor("_Color", defaultColor);
            }
        }
    }

    public void DeductHealth(float deductHealth)
    {
        Debug.Log(health);
        
        health -= attackDmg;
        flashCounter = flashLength;
        renderer.material.SetColor("_Color", Color.red);
    }

    void EnemyDead()
    {
        Destroy(gameObject);
    }
}