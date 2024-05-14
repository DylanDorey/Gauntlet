using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Bson;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/16/2024]
 * [A Ghost enemy that hurts the player upon contact]
 */

public class Ghost : Enemy
{
    public override void Start()
    {
        //adds enemy to active enemies list
        base.Start();

        //initialize all enemy variables
        InitializeEnemy(20, 2.5f, 10, 5, 10f);

        //add the kamikaze behavior and set the enemy behavior
        gameObject.AddComponent<Kamikaze>();
        enemyBehavior = GetComponent<Kamikaze>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        //if the collision is with a player
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            //set collision in kamikaze to the player
            GetComponent<Kamikaze>().collision = collision;

            //apply the kamikaze behavior
            ApplyBehavior(enemyBehavior);
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
