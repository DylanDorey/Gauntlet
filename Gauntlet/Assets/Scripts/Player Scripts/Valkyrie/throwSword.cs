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
        Valkyrie valkyrie = player.gameObject.GetComponent<Valkyrie>();

        for (int index = 0; index< 1; index++)
        {
            hasFired = true;

            GameObject sword = Instantiate(valkyrie.swordPrefab, valkyrie.swordSpawnpos.position, valkyrie.swordPrefab.transform.rotation);

            sword.GetComponent<Sword>().moveDirection = transform.GetChild(0).transform.forward;

            AudioManager.Instance.AddToSoundQueue(valkyrie.throwSwordSound);

            yield return new WaitForSeconds(valkyrie.throwDelay);
        }
        hasFired = false;
    }
}
