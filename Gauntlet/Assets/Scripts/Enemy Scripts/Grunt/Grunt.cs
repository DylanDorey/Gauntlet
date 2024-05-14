using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : Enemy
{
    public float meleeDelay = 2f;
    public bool hasMeleed = false;
    public Collision playerCollision;

    public override void Start()
    {
        base.Start();

        InitializeEnemy(10, 2f, 5, 5, 10f);

        gameObject.AddComponent<GruntMelee>();
        enemyBehavior = GetComponent<GruntMelee>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<PlayerController>())
        {
            if (!hasMeleed)
            {
                playerCollision = collision;
                ApplyBehavior(enemyBehavior);
            }
        }

        if (enemyHealth <= 0)
        {
            if (collision.transform.GetComponent<Axe>() || collision.transform.GetComponent<Fireball>() || collision.transform.GetComponent<Sword>())
            {
                UIManager.Instance.warrior.gameObject.GetComponent<PlayerData>().playerScore += PassPoints();
            }
        }
    }
}
