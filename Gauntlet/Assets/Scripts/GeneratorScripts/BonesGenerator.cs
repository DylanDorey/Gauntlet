using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/18/2024]
 * [A generator that only spawns ghosts and can be destroyed by specific projectiles]
 */

public class BonesGenerator : Generator
{
    //prefabs for the different level generators and enemies
    public GameObject level1Prefab, level2Prefab, level3Prefab;
    public GameObject ghostPrefab;

    private void Start()
    {
        //initializes generator properties
        InitializeGenerator(Random.Range(1, 4), 1, 1f, GeneratorType.Bones);
        InitializeLevelGenerator();
    }

    /// <summary>
    /// Starts spawning enemies
    /// </summary>
    public void StartSpawningEnemies()
    {
        StartCoroutine(SpawnEnemies());
    }

    /// <summary>
    /// Stops spawning enemies
    /// </summary>
    public void StopSpawningEnemies()
    {
        StopCoroutine(SpawnEnemies());
    }

    /// <summary>
    /// Spawns ghost enemies at a specific spawn rate
    /// </summary>
    /// <returns> the time between spawns </returns>
    private IEnumerator SpawnEnemies()
    {
        for (int index = 0; index < 1; index++)
        {
            //set has spawned enemy to true
            hasSpawnedEnemy = true;

            //initialize the random spawn location index
            int spawnLocation = Random.Range(0, spawnPoints.Length);

            //spawn ghost at random spawn index
            GameObject ghost = Instantiate(ghostPrefab, spawnPoints[spawnLocation].position, Quaternion.identity);

            //initialize the ghost's level on spawn
            ghost.GetComponent<Enemy>().enemyLevel = generatorLevel;

            //wait the spawn delay before spawning another enemy
            yield return new WaitForSeconds(spawnRate);
        }

        //set has spawned enemy to false after spawn delay
        hasSpawnedEnemy = false;
    }

    /// <summary>
    /// Initializes the generator display prefab based on the generators level
    /// </summary>
    private void InitializeLevelGenerator()
    {
        GameObject prefab;

        //based on the generators level
        switch (generatorLevel)
        {
            //if 1
            case 1:
                //spawn level 1 prefab and set it as a child of this game object
                prefab = Instantiate(level1Prefab, transform.position, Quaternion.identity);
                prefab.transform.parent = this.transform;
                break;

            //if 2
            case 2:
                //spawn level 2 prefab and set it as a child of this game object
                prefab = Instantiate(level2Prefab, transform.position, Quaternion.identity);
                prefab.transform.parent = this.transform;
                break;

            //if 3
            case 3:
                //spawn level 3 prefab and set it as a child of this game object
                prefab = Instantiate(level3Prefab, transform.position, Quaternion.identity);
                prefab.transform.parent = this.transform;
                break;
        }
    }
}
