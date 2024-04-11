using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMelee : Warrior, IPlayerBehavior
{
    private RaycastHit hit;
    private Vector3 rayDirection = new Vector3.forward();
    private float rayDistance = 2f;

    public void PlayerBehavior(PlayerController player)
    {
        StartCoroutine(Melee());
    }

    /// <summary>
    /// allows the player to hit directly in front of them
    /// </summary>
    private IEnumerator Melee()
    {
        while(true)
        {
            if (Physics.Raycast(transform.position, rayDirection, out hit, rayDistance))
            {
                Debug.DrawRay(transform.position, rayDirection, Color.green);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
