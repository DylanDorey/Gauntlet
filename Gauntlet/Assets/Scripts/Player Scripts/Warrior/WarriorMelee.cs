using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMelee : Warrior, IMeleeBehavior
{
    public void MeleeBehavior(PlayerController player)
    {
        StartCoroutine(Melee(player));
    }

    /// <summary>
    /// allows the player to hit directly in front of them
    /// </summary>
    public IEnumerator Melee(PlayerController player)
    {
        while (true)
        {
            Debug.Log("Ray");
            if (Physics.Raycast(player.transform.position, rayDirection, out hit, meleeDistance))
            {
                Debug.DrawRay(player.transform.position, rayDirection, Color.green);
            }
            yield return new WaitForSeconds(meleeDelay);
        }
    }
}
