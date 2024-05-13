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
    public bool hasMeleed = false;

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
        Warrior warrior = player.gameObject.GetComponent<Warrior>();

        for (int index = 0; index < 1; index++)
        {
            if (Physics.Raycast(player.transform.position, warrior.rayDirection, out warrior.hit, warrior.meleeDistance))
            {
                hasMeleed = true;
                Debug.DrawRay(player.transform.position, warrior.rayDirection, Color.red);

                if (warrior.hit.collider.transform.GetComponent<Enemy>())
                {
                    warrior.hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(warrior.meleeDamage);
                    AudioManager.Instance.AddToSoundQueue(warrior.meleeSound);
                }

                yield return new WaitForSeconds(warrior.meleeDelay);
            }

            hasMeleed = false;
        }
    }
}
