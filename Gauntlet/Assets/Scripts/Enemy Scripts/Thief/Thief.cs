using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/21/2024]
 * [An enemy that takes items from players at random points in the game and flees]
 */

public class Thief : Enemy
{
    //thief variables
    public AudioClip thiefTone;

    public bool hasStolen = false;
    public bool hasDied = false;

    public override void Start()
    {
        //add enemy to active enemies list
        base.Start();

        //initialize all enemy values
        InitializeEnemy(500, 8f, 10, 10f, 50f);

        //initialize enemy behavior to steal behavior
        enemyBehavior = GetComponent<Steal>();

        //initialize the target pos to a random player
        targetPos = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;

        //set has stolen to false
        hasStolen = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        //if the collision is with a player
        if (collision.transform.GetComponent<PlayerController>())
        {
            //set the players inventory in the steal class and player data
            GetComponent<Steal>().playerInventory = collision.transform.GetComponent<InventoryManager>();
            GetComponent<Steal>().playerData = collision.transform.GetComponent<PlayerData>();

            //remove health from player
            collision.transform.GetComponent<PlayerData>().playerHealth -= enemyDamage;

            //if the thief has not stolen
            if (!hasStolen)
            {
                //steal something
                ApplyBehavior(enemyBehavior);
            }
            else
            {
                //otherwise flee
                transform.GetChild(0).gameObject.SetActive(false);
                StartCoroutine(Flee());
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

    /// <summary>
    /// Drops stolen item on death
    /// </summary>
    public override void OnDeath()
    {
        //if has stolen something
        if (hasStolen)
        {
            //spawn the stolen item
            Instantiate(GetComponent<Steal>().stolenItem, transform.position, Quaternion.identity);
        }

        //set has dies to true
        hasDied = true;

        base.OnDeath();
    }

    /// <summary>
    /// Runs towards the exit when something has been stolen
    /// </summary>
    /// <returns> the flee time </returns>
    public IEnumerator Flee()
    {
        //set the target pos to the exit and play the thief tone
        targetPos = GameObject.FindGameObjectWithTag("Exit").gameObject.transform.position;
        AudioManager.Instance.AddToSoundQueue(thiefTone);

        for (int index = 0; index < 1; index++)
        {
            yield return new WaitForSeconds(5f);
        }

        //set has died to false
        hasDied = false;

        //if an item was stolen send it to the level manager for next level spawn
        if (GetComponent<Steal>().stolenItem != null)
        {
            LevelManager.Instance.thiefItem = GetComponent<Steal>().stolenItem;
        }

        //set the active of the thief to false
        gameObject.SetActive(false);
    }
}
