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
    private bool hasShot = false;

    public void ShootBehavior(PlayerController player)
    {
        if (!hasShot)
        {
            StartCoroutine(Throw(player));
        }
    }

    /// <summary>
    /// allows the player to throw a fireball
    /// </summary>
    public IEnumerator Throw(PlayerController player)
    {
        Wizard wizard = player.gameObject.GetComponent<Wizard>();

        for (int index = 0; index < 1; index++)
        {
            hasShot = true;

            GameObject fireball = Instantiate(wizard.fireballPrefab, wizard.fireballSpawnPos.position, wizard.fireballPrefab.transform.rotation);

            fireball.GetComponent<Fireball>().moveDirection = transform.GetChild(0).transform.forward;

            AudioManager.Instance.AddToSoundQueue(wizard.throwFireballSound);

            yield return new WaitForSeconds(wizard.throwDelay);
        }

        hasShot = false;
    }
}
