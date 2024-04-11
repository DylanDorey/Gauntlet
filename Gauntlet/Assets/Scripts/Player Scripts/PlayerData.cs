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
    public float health;

    [Range(1f, 5f)]
    public float healthTickRate;

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

    /// <summary>
    /// removes 1 health from the player
    /// </summary>
    /// <returns> the players health </returns>
    private float HealthTick()
    {
        //remove 1 health
        health -= 1f;

        //return new health value
        return health;
    }
}
