using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steal : MonoBehaviour, IEnemyBehavior
{
    public InventoryManager playerInventory;
    public PlayerData playerData;

    public GameObject key;
    public GameObject bluePotion;
    public GameObject orangePotion;

    public GameObject stolenItem;

    public void Behavior(Enemy enemy)
    {
        InitiateSteal();
    }

    public void InitiateSteal()
    {
        if (playerInventory != null)
        {
            if (playerData.hasKey)
            {
                playerInventory.RemoveKeyOnUse();
                stolenItem = key;
            }
            else if (playerData.hasPotion)
            {
                playerInventory.RemovePotionOnUse();
                stolenItem = bluePotion;
            }
            else
            {
                playerData.playerScore -= Random.Range(100, 301);

                if(playerData.playerScore < 0)
                {
                    playerData.playerScore = 0;
                }
            }

            //once the thief has stolen something set the targetPos to the exit
            GetComponent<Thief>().hasStolen = true;
            StartCoroutine(GetComponent<Thief>().Flee());
        }
    }
}
