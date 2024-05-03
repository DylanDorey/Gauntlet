using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/18/2024]
 * [A generator that spawns all enemies except ghosts and can only be weakend by specific projectiles]
 */

public class BlockGenerator : Generator
{
    public GameObject level1Prefab, level2Prefab, level3Prefab;
    public GameObject[] enemiesToSpawn;

    private void Start()
    {
        InitializeGenerator(Random.Range(1, 4), 1, 5f, GeneratorType.Block);
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
        yield return new WaitForSeconds(spawnRate);
    }

    private void VerifyDamage()
    {

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
