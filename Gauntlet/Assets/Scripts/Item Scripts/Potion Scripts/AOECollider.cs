using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [05/02/2024]
 * [The radius collider for potions that removes enemies]
 */
public class AOECollider : MonoBehaviour
{
    //AOE variables
    public Vector3 scaleFactor;
    public PlayerData usedBy;

    private void Start()
    {
        //on spawn in start increasing in size
        StartCoroutine(IncreaseSize());
    }

    private void OnTriggerEnter(Collider other)
    {  
        //if an enemy is in the AOE
        if (other.transform.GetComponent<Enemy>())
        {
            //But if it is death
            if(other.gameObject.GetComponent<Death>())
            {
                //and if it was used by a player
                if(usedBy != null)
                {
                    //add Deaths current score worth to the player's score
                    usedBy.playerScore += other.gameObject.GetComponent<Death>().enemyPoints;
                }
            }
            else
            {
                //otherwise call on death
                other.gameObject.GetComponent<Enemy>().OnDeath();
            }
        }
    }

    /// <summary>
    /// Increases the AOE over a certain amount of time based on the players magic stat
    /// </summary>
    /// <returns> the time between AOE size increase </returns>
    private IEnumerator IncreaseSize()
    {
        //set scale factor to a default size
        transform.localScale = scaleFactor;

        //for 4 iterations
        for (int index = 0; index < 4; index++)
        {
            //increase by the scale factor
            transform.localScale += scaleFactor;

            //wait 0.1 seconds
            yield return new WaitForSeconds(0.1f);
        }

        //destroy the AOE
        Destroy(gameObject);
    }
}
