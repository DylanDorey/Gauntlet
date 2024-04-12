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
        for (int index = 0; index < 1; index++)
        {
            hasShot = true;

            GameObject fireball = Instantiate(player.gameObject.GetComponent<Wizard>().fireballPrefab, player.gameObject.GetComponent<Wizard>().fireballSpawnPos.position, player.gameObject.GetComponent<Wizard>().fireballPrefab.transform.rotation);

            fireball.GetComponent<Fireball>().moveDirection = transform.GetChild(0).transform.forward;

            yield return new WaitForSeconds(player.gameObject.GetComponent<Wizard>().throwDelay);
        }

        hasShot = false;
    }
}
