using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/17/2024]
 * [The Melee behavior of the Grunt Enemy]
 */

public class GruntMelee : MonoBehaviour, IEnemyBehavior
{
    public void Behavior(Enemy enemy)
    {
        //start Melee behavior
        StartCoroutine(Melee(enemy));
    }

    /// <summary>
    /// allows the Grunt to hit directly in front of them
    /// </summary>
    private IEnumerator Melee(Enemy enemy)
    {
        //store grunt component into a variable
        Grunt grunt = enemy.GetComponent<Grunt>();

        //set has meleed to true to start melee delay
        grunt.hasMeleed = true;

        for (int index = 0; index < 1; index++)
        {
            //deal damage to player
            grunt.playerCollision.gameObject.GetComponent<PlayerData>().TakeDamage(grunt.enemyDamage);

            //wait for the melee delay
            yield return new WaitForSeconds(grunt.meleeDelay);
        }

        //set has meleed to false
        grunt.hasMeleed = false;
    }
}
