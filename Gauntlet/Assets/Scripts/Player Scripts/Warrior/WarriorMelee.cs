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
    private bool hasMeleed = false;

    public void MeleeBehavior(PlayerController player)
    {
        if(!hasMeleed)
        {
            StartCoroutine(Melee(player));
        }
    }

    /// <summary>
    /// allows the player to hit directly in front of them
    /// </summary>
    public IEnumerator Melee(PlayerController player)
    {
        for (int index = 0; index < 1; index++)
        {
            if (Physics.Raycast(player.transform.position, player.gameObject.GetComponent<Warrior>().rayDirection, out player.gameObject.GetComponent<Warrior>().hit, player.gameObject.GetComponent<Warrior>().meleeDistance))
            {
                hasMeleed = true;
                Debug.DrawRay(player.transform.position, player.gameObject.GetComponent<Warrior>().rayDirection, Color.red);

                //if (player.gameObject.GetComponent<Warrior>().hit.collider.gameObject.GetComponent<Enemy>())
                //{
                //    player.gameObject.GetComponent<Warrior>().hit.collider.gameObject.GetComponent<Enemy>().enemyHealth -= player.gameObject.GetComponent<Warrior>().meleeDamage;
                //}

                yield return new WaitForSeconds(player.gameObject.GetComponent<Warrior>().meleeDelay);
            }

            hasMeleed = false;
        }
    }
}
