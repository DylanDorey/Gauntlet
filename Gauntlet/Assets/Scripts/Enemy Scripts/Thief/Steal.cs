using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/21/2024]
 * [The steal beahvior of the enemy thief]
 */

public class Steal : MonoBehaviour, IEnemyBehavior
{
    //steal variables
    public InventoryManager playerInventory;
    public PlayerData playerData;

    public GameObject key;
    public GameObject bluePotion;
    public GameObject orangePotion;

    public GameObject stolenItem;

    public void Behavior(Enemy enemy)
    {
        //initiates the steal behavior
        InitiateSteal();
    }

    /// <summary>
    /// Takes any item from the players inventory and runs towards the exit door
    /// </summary>
    public void InitiateSteal()
    {
        //if the player's inventory is not null
        if (playerInventory != null)
        {
            //if the player has a key
            if (playerData.hasKey)
            {
                //take the key
                playerInventory.RemoveKeyOnUse();
                stolenItem = key;
            }
            //if the player has a potion
            else if (playerData.hasPotion)
            {
                //take the potion
                playerInventory.RemovePotionOnUse();
                stolenItem = bluePotion;
            }
            else
            //otherwise take the players points
            {
                playerData.playerScore -= Random.Range(100, 301);

                if(playerData.playerScore < 0)
                {
                    playerData.playerScore = 0;
                }
            }

            //once the thief has stolen something set the targetPos to the exit and flee
            GetComponent<Thief>().hasStolen = true;
            StartCoroutine(GetComponent<Thief>().Flee());
        }
    }
}
