using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwSword : MonoBehaviour, IShootBehavior
{
    private bool hasFired = false;

    public void ShootBehavior(PlayerController player)
    {
        if (!hasFired)
        {
            StartCoroutine(Throw(player));
        }


    }

    public IEnumerator Throw(PlayerController player)
    {
        for (int index = 0; index< 1; index++)
        {
            hasFired = true;

            GameObject sword = Instantiate(player.gameObject.GetComponent<Valkyrie>().swordPrefab, player.gameObject.GetComponent<Valkyrie>().swordSpawnpos.position, player.gameObject.GetComponent<Valkyrie>().swordPrefab.transform.rotation);

            sword.GetComponent<Sword>().moveDirection = transform.GetChild(0).transform.forward;

            yield return new WaitForSeconds(player.gameObject.GetComponent<Valkyrie>().throwDelay);
        }
        hasFired = false;
    }
}
