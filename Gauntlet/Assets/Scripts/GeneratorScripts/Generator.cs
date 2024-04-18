using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int generatorLevel;
    public float generatorHealth;
    public float spawnRate;
    public List<Transform> spawnPoints;

    public virtual void OnCollisionEnter(Collision collision)
    {
        
    }

    public void InitializeGenerator(int level, float health, float rate)
    {
        generatorLevel = level;
        generatorHealth = health;
        spawnRate = rate;
    }

    public void SpawnEnemy(GameObject enemy, Vector3 location)
    {
        //store a random position from the spawnPoints list into an index
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Count);

        //set location equal to that random position index
        location = spawnPoints[randomSpawnPointIndex].position;


    }

    public void AcceptDamage(float amount)
    {
        //Check if what hit the generator was a valid object to deal damage

        //If it was, remove health
        generatorHealth -= amount;


        //Decrease spawnRate based upon health value
    }
}
