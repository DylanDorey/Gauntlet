using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/18/2024]
 * [Base class for generators]
 */

public enum GeneratorType
{
    Bones,
    Block
}

public class Generator : MonoBehaviour
{
    public int generatorLevel;
    public int generatorHitpoints;
    public float spawnRate;
    public GeneratorType generatorType;
    public Transform[] spawnPoints;

    public virtual void OnCollisionEnter(Collision collision)
    {
        
    }

    public void InitializeGenerator(int level, int hitpoints, float rate, GeneratorType type)
    {
        generatorLevel = level;
        generatorHitpoints = hitpoints * level;
        spawnRate = rate;
        generatorType = type;
    }

    public void AcceptDamage(float amount)
    {
        //Check if what hit the generator was a valid object to deal damage

        //If it was, remove health
        //generatorHitpoints -= amount;


        //Decrease spawnRate based upon health value
    }

    public void OnGeneratorDeath()
    {
        Destroy(gameObject);
    }
}
