using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : MonoBehaviour
{
    public float health = 500.0f;
    EnemyHealthSystem enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0.0f)
        {
            Destroy(this);
            //add wall crumbling anim
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Generic")
        {
            health -= enemy.attackDmg;
        }
    }
}
