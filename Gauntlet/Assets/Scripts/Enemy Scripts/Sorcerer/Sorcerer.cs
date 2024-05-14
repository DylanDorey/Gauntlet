using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/19/2024]
 * [A Sorcerer enemy that blinks in and out of existence]
 */

public class Sorcerer : Enemy
{
    //sorcerer variables
    private bool hasMeleed = false;
    private bool inMeleeDistance = false;
    private readonly float meleeDelay = 3f;

    public override void Start()
    {
        //add enemy to active enemies list
        base.Start();

        //initialize all sorcerer values
        InitializeEnemy(10, 3f, 5, 5, 10f);

        //add the sorcerer blink component and initialze the enemy behavior
        gameObject.AddComponent<SorcererBlink>();
        enemyBehavior = GetComponent<SorcererBlink>();

        //start the behavior
        ApplyBehavior(enemyBehavior);
    }

    public void OnCollisionEnter(Collision collision)
    {
        //if the collision is with a player 
        if (collision.transform.GetComponent<PlayerController>())
        {
            //and the sorcerer has not meleed
            if (!hasMeleed)
            {
                //set in melee distance to true and start meleeing
                inMeleeDistance = true;
                StartCoroutine(Melee(collision));
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

    private void OnCollisionExit(Collision collision)
    {
        //on collision exit set in melee distance to false
        inMeleeDistance = false;
    }

    /// <summary>
    /// Melees every desired duration when in range
    /// </summary>
    /// <param name="collision">the collided object </param>
    /// <returns> time between melees</returns>
    private IEnumerator Melee(Collision collision)
    {
        //while in melee distance
        while (inMeleeDistance)
        { 
            //set has melee to true
            hasMeleed = true;

            //remove health from player
            collision.gameObject.GetComponent<PlayerData>().TakeDamage(enemyDamage);

            //wait the melee delay
            yield return new WaitForSeconds(meleeDelay);
        }

        //set has meleed to false
        hasMeleed = false;
    }
}
