using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/11/2024]
 * [Allows Player melee with the Warrior]
 */

public class WarriorMelee : MonoBehaviour, IMeleeBehavior
{
    //bool to create a melee delay
    public bool hasMeleed = false;

    /// <summary>
    /// Implemented melee behavior from IMeleeBehavior
    /// </summary>
    /// <param name="player">the player controller this melee behavior belongs to</param>
    public void MeleeBehavior(PlayerController player)
    {
        //if the player has not meleed
        if(!hasMeleed)
        {
            //allow melee
            StartCoroutine(Melee(player));
        }
    }

    /// <summary>
    /// allows the player to hit directly in front of them
    /// </summary>
    /// <param name="player"> the player controller this melee behavior belongs to </param>
    /// <returns> the time between melees </returns>
    public IEnumerator Melee(PlayerController player)
    {
        //store warrior reference  into a variable
        Warrior warrior = player.gameObject.GetComponent<Warrior>();

        for (int index = 0; index < 1; index++)
        {
            //if the raycast hits something
            if (Physics.Raycast(player.transform.position, warrior.rayDirection, out warrior.hit, warrior.meleeDistance))
            {
                //set has melee to true
                hasMeleed = true;

                //if the something is an enemy
                if (warrior.hit.collider.transform.GetComponent<Enemy>())
                {
                    //take health away from the enemy and play the melee sound
                    warrior.hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(warrior.meleeDamage);
                    AudioManager.Instance.AddToSoundQueue(warrior.meleeSound);
                }

                //add melee delay
                yield return new WaitForSeconds(warrior.meleeDelay);
            }

            //set hasMeleed back to false after delay
            hasMeleed = false;
        }
    }
}
