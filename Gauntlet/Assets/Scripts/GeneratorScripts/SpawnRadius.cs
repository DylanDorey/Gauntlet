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
    private Generator generator;

    private void Awake()
    {
        if (transform.parent != null)
        {
            generator = GetComponentInParent<Generator>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (generator.hasSpawnedEnemy == false)
        {
            if (other.transform.GetComponent<PlayerController>())
            {
                if (generator.generatorType == GeneratorType.Bones)
                {
                    GetComponentInParent<BonesGenerator>().StartSpawningEnemies();
                }

                if (generator.generatorType == GeneratorType.Block)
                {
                    GetComponentInParent<BlockGenerator>().StartSpawningEnemies();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.GetComponent<PlayerController>())
        {
            if (generator.generatorType == GeneratorType.Bones)
            {
                GetComponentInParent<BonesGenerator>().StopSpawningEnemies();
            }

            if (generator.generatorType == GeneratorType.Block)
            {
                GetComponentInParent<BlockGenerator>().StopSpawningEnemies();
            }
        }
    }
}
