using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/13/2024]
 * [Spawns in an axe that is thrown away from the Warrior player]
 */

public class ThrowAxe : MonoBehaviour, IShootBehavior
{
    //bool to create a shooting delay
    private bool hasShot = false;

    /// <summary>
    /// The implemented shooting behavior from IShootBehavior
    /// </summary>
    /// <param name="player">the player controller this shooting behavior belongs to</param>
    public void ShootBehavior(PlayerController player)
    {
        //if the player has not shot
        if (!hasShot)
        {
            //allow shooting
            StartCoroutine(Throw(player));
        }
    }

    /// <summary>
    /// allows the player to hit directly in front of them
    /// </summary>
    /// <param name="player">the player controller this shooting behavior belongs to</param>
    /// <returns> the delay bewteen shots</returns>
    public IEnumerator Throw(PlayerController player)
    {
        //store warrior reference  into a variable
        Warrior warrior = player.gameObject.GetComponent<Warrior>();

        for (int index = 0; index < 1; index++)
        {
            //set has shot to true
            hasShot = true;

            //spawn an axe projectile prefab at the the projectile spawn pos
            GameObject axe = Instantiate(warrior.axePrefab, warrior.axeSpawnPos.position, warrior.axePrefab.transform.rotation);

            //set the move direction of the axe
            axe.GetComponent<Axe>().moveDirection = transform.GetChild(0).transform.forward;

            //play the shooting audio clip
            AudioManager.Instance.AddToSoundQueue(warrior.axeThrowSound);

            //wait before allowing another shot to be fired
            yield return new WaitForSeconds(warrior.throwDelay);
        }

        //set hasShot to false after delay
        hasShot = false;
    }
}
