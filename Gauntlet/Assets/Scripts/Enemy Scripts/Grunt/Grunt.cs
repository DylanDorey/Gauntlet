using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/17/2024]
 * [A Grunt enemy that hurts the player upon contact]
 */

public class Grunt : Enemy
{
    //Grunt variables
    public float meleeDelay = 2f;
    public bool hasMeleed = false;
    public Collision playerCollision;

    public override void Start()
    {
        //add enemy to active enemies list
        base.Start();

        //initialize all enemy values
        InitializeEnemy(10, 2f, 5, 5, 10f);

        //add Grunt Melee component and initialize enemy behavior
        gameObject.AddComponent<GruntMelee>();
        enemyBehavior = GetComponent<GruntMelee>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        //if the collision is with a player
        if (collision.transform.GetComponent<PlayerController>())
        {
            //if the grunt has not meleed
            if (!hasMeleed)
            {
                //set the player collision to this collision and apply the behavior
                playerCollision = collision;
                ApplyBehavior(enemyBehavior);
            }
        }

        //if the enemy is dead
        if (enemyHealth <= 0)
        {
            if (collision.transform.GetComponent<Axe>())
            {
                //add score to the warrior
                UIManager.Instance.warrior.gameObject.GetComponent<PlayerData>().playerScore += PassPoints();
            }
            else if (collision.transform.GetComponent<Fireball>())
            {
                //add score to the wizard
                UIManager.Instance.wizard.gameObject.GetComponent<PlayerData>().playerScore += PassPoints();
            }
            else if (collision.transform.GetComponent<Sword>())
            {
                //add score to the valkyrie
                UIManager.Instance.valkyrie.gameObject.GetComponent<PlayerData>().playerScore += PassPoints();
            }
            else if (collision.transform.GetComponent<Arrow>())
            {
                //add score to the player
                UIManager.Instance.elf.gameObject.GetComponent<PlayerData>().playerScore += PassPoints();
            }

            OnDeath();
        }
    }
}
