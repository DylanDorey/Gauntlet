using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordMelee : MonoBehaviour, IMeleeBehavior
{
    private bool hasAttacked = false;

    public void MeleeBehavior(PlayerController player)
    {
        if (!hasAttacked)
        {
            StartCoroutine(Swing(player));
        }
    }

    public IEnumerator Swing(PlayerController player)
    {
        Valkyrie valkyrie = player.gameObject.GetComponent<Valkyrie>();

        for (int index = 0; index < 1; index++)
        {
            if (Physics.Raycast(player.transform.position, valkyrie.hitPoint, out valkyrie.hit, valkyrie.meleeDistance))
            {
                hasAttacked = true;
                Debug.DrawRay(player.transform.position, valkyrie.hitPoint, Color.red);

                if (valkyrie.hit.collider.transform.GetComponent<Enemy>())
                {
                   valkyrie.hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(valkyrie.swingDamage);
                   AudioManager.Instance.AddToSoundQueue(valkyrie.valkyrieMeleeSound);
                }

                yield return new WaitForSeconds(valkyrie.swingDelay);
            }

            hasAttacked = false;
        }
    }
}
