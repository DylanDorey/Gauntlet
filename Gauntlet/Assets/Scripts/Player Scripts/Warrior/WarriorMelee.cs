using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMelee : Warrior, IMeleeBehavior
{
    public void MeleerBehavior(PlayerController player)
    {
        Melee();
    }

    /// <summary>
    /// allows the player to hit directly in front of them
    /// </summary>
    private void Melee()
    { 
        
    }
}
