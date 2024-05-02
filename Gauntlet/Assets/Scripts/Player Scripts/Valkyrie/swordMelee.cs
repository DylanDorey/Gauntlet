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
        for (int index = 0; index < 1; index++)
        {
            if (Physics.Raycast(player.transform.position, player.gameObject.GetComponent<Valkyrie>().hitPoint, out player.gameObject.GetComponent<Valkyrie>().hit, player.gameObject.GetComponent<Valkyrie>().meleeDistance))
            {
                hasAttacked = true;
                Debug.DrawRay(player.transform.position, player.gameObject.GetComponent<Valkyrie>().hitPoint, Color.red);

                yield return new WaitForSeconds(player.gameObject.GetComponent<Valkyrie>().swingDelay);
            }

            hasAttacked = false;
        }
    }
}
