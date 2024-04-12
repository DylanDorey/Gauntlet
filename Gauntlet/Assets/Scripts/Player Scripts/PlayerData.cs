using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/10/2024]
 * [Stores all player data related to number values, such as stats]
 */

//various base player states
public enum PlayerEvent
{
    OnSpawn,
    OnDeath
}

public class PlayerData : MonoBehaviour
{
    public float playerHealth;
    public float playerMagic;
    public float playerArmor;
    public float playerSpeed;

    [Range(1f, 5f)]
    public float healthTickRate;

    public bool hasMelee;

    // Start is called before the first frame update
    void Start()
    {
        //start health drain system
        InvokeRepeating("HealthTick", 3f, healthTickRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializePlayerData(float health, float magic, float armor, float speed, bool isMelee)
    {
        playerHealth = health;
        playerMagic = magic;
        playerArmor = armor;
        playerSpeed = speed;
        hasMelee = isMelee;
    }

    /// <summary>
    /// Takes health away from player whenever taking damage
    /// </summary>
    /// <param name="damage"> the incoming damage </param>
    /// <returns></returns>
    public float TakeDamage(float damage)
    {
        //remove the damage value from the players health, then return the players new health
        playerHealth -= damage/playerArmor;

        return playerHealth;
    }

    /// <summary>
    /// removes 1 health from the player
    /// </summary>
    /// <returns> the players health </returns>
    private float HealthTick()
    {
        //remove 1 health
        playerHealth -= 1f;

        //return new health value
        return playerHealth;
    }
}
