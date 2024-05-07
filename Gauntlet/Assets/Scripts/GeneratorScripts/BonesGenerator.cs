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
    public GameObject level1Prefab, level2Prefab, level3Prefab;
    public GameObject ghostPrefab;

    private void Start()
    {
        InitializeGenerator(Random.Range(1, 4), 1, 2f, GeneratorType.Bones);
        InitializeLevelGenerator();
    }

    public void StartSpawningEnemies()
    {
        StartCoroutine(SpawnEnemies());
    }

    public void StopSpawningEnemies()
    {
        StopCoroutine(SpawnEnemies());
    }


    private IEnumerator SpawnEnemies()
    {
        for (int index = 0; index < 1; index++)
        {
            hasSpawnedEnemy = true;

            int spawnLocation = Random.Range(0, spawnPoints.Length);

            GameObject ghost = Instantiate(ghostPrefab, spawnPoints[spawnLocation].position, Quaternion.identity);

            ghost.GetComponent<Enemy>().enemyLevel = generatorLevel;

            yield return new WaitForSeconds(spawnRate);
        }

        hasSpawnedEnemy = false;
    }

    private void InitializeLevelGenerator()
    {
        GameObject prefab;

        switch (generatorLevel)
        {
            case 1:
                prefab = Instantiate(level1Prefab, transform.position, Quaternion.identity);
                prefab.transform.parent = this.transform;
                break;
            case 2:
                prefab = Instantiate(level2Prefab, transform.position, Quaternion.identity);
                prefab.transform.parent = this.transform;
                break;
            case 3:
                prefab = Instantiate(level3Prefab, transform.position, Quaternion.identity);
                prefab.transform.parent = this.transform;
                break;
        }
    }
}
