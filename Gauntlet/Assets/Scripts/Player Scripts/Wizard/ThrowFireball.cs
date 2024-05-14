using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/11/2024]
 * [A throwable fireball that the wizard can throw]
 */

public class ThrowFireball : MonoBehaviour, IShootBehavior
{
    //bool to add delay after a shot has be fired
    private bool hasShot = false;

    /// <summary>
    /// Shooting behavior from IShootBehavior
    /// </summary>
    /// <param name="player"> the player with this shooting mechanic </param>
    public void ShootBehavior(PlayerController player)
    {
        //if the player has not shot
        if (!hasShot)
        {
            //shoot
            StartCoroutine(Throw(player));
        }
    }

    /// <summary>
    /// Allows the player to shoot a fireball
    /// </summary>
    /// <param name="player"> the player that implements this shooting mechanic </param>
    /// <returns> the time between shots </returns>
    public IEnumerator Throw(PlayerController player)
    {
        //store wizard component in variable
        Wizard wizard = player.gameObject.GetComponent<Wizard>();

        for (int index = 0; index < 1; index++)
        {
            //set has shot to true
            hasShot = true;

            //spawn a fireball at the projectile spawn pos
            GameObject fireball = Instantiate(wizard.fireballPrefab, wizard.fireballSpawnPos.position, wizard.fireballPrefab.transform.rotation);

            //set the move direction to forward from the current players looking direction
            fireball.GetComponent<Fireball>().moveDirection = transform.GetChild(0).transform.forward;

            //play shooting sound
            AudioManager.Instance.AddToSoundQueue(wizard.throwFireballSound);

            //wait to fire next shot
            yield return new WaitForSeconds(wizard.throwDelay);
        }

        //set has shot to false after delay
        hasShot = false;
    }
}
