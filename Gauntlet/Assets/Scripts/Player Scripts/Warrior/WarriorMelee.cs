using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMelee : Warriro, IPlayerBehavior
{
    public void PlayerBehavior(PlayerController player)
    {
        StartCoroutine(Melee());
    }

    /// <summary>
    /// allows the player to hit directly in front of them
    /// </summary>
    public IEnumerator Melee()
    {
        while(true)
        {
            if (Physics.Raycast(transform.position, rayDirection, out hit, meleeDistance))
            {
                Debug.DrawRay(transform.position, rayDirection, Color.green);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
