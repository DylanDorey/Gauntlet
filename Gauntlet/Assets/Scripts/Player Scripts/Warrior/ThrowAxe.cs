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
    private bool hasShot = false;

    public void ShootBehavior(PlayerController player)
    {
        if (!hasShot)
        {
            StartCoroutine(Throw(player));
        }
    }

    /// <summary>
    /// allows the player to hit directly in front of them
    /// </summary>
    public IEnumerator Throw(PlayerController player)
    {
        Warrior warrior = player.gameObject.GetComponent<Warrior>();

        for (int index = 0; index < 1; index++)
        {
            hasShot = true;

            GameObject axe = Instantiate(warrior.axePrefab, warrior.axeSpawnPos.position, warrior.axePrefab.transform.rotation);

            axe.GetComponent<Axe>().moveDirection = transform.GetChild(0).transform.forward;

            AudioManager.Instance.AddToSoundQueue(warrior.axeThrowSound);

            yield return new WaitForSeconds(warrior.throwDelay);
        }

        hasShot = false;
    }
}
