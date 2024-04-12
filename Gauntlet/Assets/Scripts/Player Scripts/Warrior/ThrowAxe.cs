using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        for (int index = 0; index < 1; index++)
        {
            hasShot = true;

            GameObject axe = Instantiate(player.gameObject.GetComponent<Warrior>().axePrefab, player.transform.position, player.gameObject.GetComponent<Warrior>().axePrefab.transform.rotation);

            axe.GetComponent<Axe>().moveDirection = transform.GetChild(0).transform.forward;

            yield return new WaitForSeconds(player.gameObject.GetComponent<Warrior>().throwDelay);
        }

        hasShot = false;
    }
}
