using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/18/2024]
 * [Base class for generators]
 */

//the type of generator
public enum GeneratorType
{
    Bones,
    Block
}

public class Generator : MonoBehaviour
{
    //generator variables
    public int generatorLevel;
    public int generatorHitpoints;
    public float spawnRate;
    public GeneratorType generatorType;
    public Transform[] spawnPoints;
    public AudioClip deathSound;
    public bool hasSpawnedEnemy = false;

    public void OnCollisionEnter(Collision collision)
    {
        //accept damage from whatever hits the generator
        AcceptDamage(collision);
    }

    /// <summary>
    /// Initializes all generator variables
    /// </summary>
    /// <param name="level"> the level of the generator </param>
    /// <param name="hitpoints"> how many hit points the generator has </param>
    /// <param name="rate"> the spawn rate </param>
    /// <param name="type"> the type of generator it is </param>
    public void InitializeGenerator(int level, int hitpoints, float rate, GeneratorType type)
    {
        generatorLevel = level;
        generatorHitpoints = hitpoints * level;
        spawnRate = rate;
        generatorType = type;
    }

    /// <summary>
    /// Accepts incoming damage
    /// </summary>
    /// <param name="collision"> the incoming collision</param>
    public void AcceptDamage(Collision collision)
    {
        //verify the damage
        VerifyDamage(collision);

        //if the generator has 0 hitpoints left
        if (generatorHitpoints <= 0)
        {
            //call the on death function
            OnGeneratorDeath();
        }
    }

    /// <summary>
    /// Verifies the incoming damage
    /// </summary>
    /// <param name="collision"> the incoming game object </param>
    private void VerifyDamage(Collision collision)
    {
        //if its a bones generator
        if (generatorType == GeneratorType.Bones)
        {
            //if the incoming game object is a projectile
            if (collision.gameObject.CompareTag("Projectile"))
            {
                //If it was, remove health and decrease spawn rate
                generatorHitpoints--;
                generatorLevel--;
                spawnRate++;
            }
        }
        //if its a block generator
        else if (generatorType == GeneratorType.Block)
        {
            //if the incoming game object is a projectile
            if (collision.gameObject.CompareTag("Projectile"))
            {
                //If it was, remove health and decrease spawn rate
                generatorHitpoints--;
                generatorLevel--;
                spawnRate++;

                //if it was a rock or a demon fireball
                if (collision.transform.GetComponent<Rock>() || collision.transform.GetComponent<demonFireball>())
                {
                    //do not destroy if it was
                    if (generatorHitpoints <= 1)
                    {
                        generatorHitpoints = 1;
                    }
                }
            }
        }
    }

    /// <summary>
    /// When the generator is out of hit points play the destroy sound and remove the game object
    /// </summary>
    public void OnGeneratorDeath()
    {
        AudioManager.Instance.AddToSoundQueue(deathSound);
        Destroy(gameObject);
    }
}
