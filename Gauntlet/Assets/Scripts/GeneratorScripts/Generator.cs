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
    public AudioClip deathSound;
    public bool hasSpawnedEnemy = false;

    public void OnCollisionEnter(Collision collision)
    {
        AcceptDamage(collision);
    }

    public void InitializeGenerator(int level, int hitpoints, float rate, GeneratorType type)
    {
        generatorLevel = level;
        generatorHitpoints = hitpoints * level;
        spawnRate = rate;
        generatorType = type;
    }

    public void AcceptDamage(Collision collision)
    {
        VerifyDamage(collision);

        if (generatorHitpoints <= 0)
        {
            OnGeneratorDeath();
        }
    }

    private void VerifyDamage(Collision collision)
    {
        if (generatorType == GeneratorType.Bones)
        {
            if (collision.gameObject.CompareTag("Projectile"))
            {
                //If it was, remove health
                generatorHitpoints--;
                generatorLevel--;
                spawnRate++;
            }
        }
        else if (generatorType == GeneratorType.Block)
        {
            if (collision.gameObject.CompareTag("Projectile"))
            {
                generatorHitpoints--;
                generatorLevel--;
                spawnRate++;

                //if (collision.transform.GetComponent<Rock>() || collision.transform.GetComponent<FireBall>())
                //{
                //    if (generatorHitpoints <= 1)
                //    {
                //        generatorHitpoints = 1;
                //    }
                //}
            }
        }
    }

    public void OnGeneratorDeath()
    {
        AudioManager.Instance.AddToSoundQueue(deathSound);
        Destroy(gameObject);
    }
}
