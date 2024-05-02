using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steal : MonoBehaviour, IEnemyBehavior
{
    public InventoryManager playerInventory;
    public PlayerData playerData;

    public void Behavior(Enemy enemy)
    {
        InitiateSteal(enemy);
    }

    public void InitiateSteal(Enemy enemy)
    {
        if (playerInventory != null)
        {
            if (playerData.hasKey)
            {
                playerInventory.RemoveKeyOnUse();
            }
            else if (playerData.hasPotion)
            {
                //playerInventory.RemovePotionOnUse();
            }
            else
            {

            }
        }
    }
}
