using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [05/03/2024]
 * [When a player enters the spawn radius and exits the radius, enemies will begin spawning, or stop spawning]
 */

public class SpawnRadius : MonoBehaviour
{
    //the generator this is attached to
    private Generator generator;

    private void Awake()
    {
        //if the Spawn radius has a parent
        if (transform.parent != null)
        {
            //initialize generator
            generator = GetComponentInParent<Generator>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //if the generator has not spawned an enemy
        if (generator.hasSpawnedEnemy == false)
        {
            //if a player is in the radius
            if (other.transform.GetComponent<PlayerController>())
            {
                //if it is a bones generator
                if (generator.generatorType == GeneratorType.Bones)
                {
                    //start spawning enemies
                    GetComponentInParent<BonesGenerator>().StartSpawningEnemies();
                }

                //if it is a block generator
                if (generator.generatorType == GeneratorType.Block)
                {
                    //start spawning enemies
                    GetComponentInParent<BlockGenerator>().StartSpawningEnemies();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if a player is in the radius
        if (other.transform.GetComponent<PlayerController>())
        {
            //if it is a bones generator
            if (generator.generatorType == GeneratorType.Bones)
            {
                //stop spawning enemies
                GetComponentInParent<BonesGenerator>().StopSpawningEnemies();
            }

            //if it is a block generator
            if (generator.generatorType == GeneratorType.Block)
            {
                //stop spawning enemies
                GetComponentInParent<BlockGenerator>().StopSpawningEnemies();
            }
        }
    }
}
