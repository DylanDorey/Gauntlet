using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntMelee : MonoBehaviour, IEnemyBehavior
{
    public void Behavior(Enemy enemy)
    {
        StartCoroutine(Melee(enemy));
    }

    /// <summary>
    /// allows the Grunt to hit directly in front of them
    /// </summary>
    private IEnumerator Melee(Enemy enemy)
    {
        Grunt grunt = enemy.GetComponent<Grunt>();

        for (int index = 0; index < 1; index++)
        {
            grunt.hasMeleed = true;
            grunt.hit.transform.gameObject.GetComponent<PlayerData>().TakeDamage(grunt.enemyDamage);
            yield return new WaitForSeconds(grunt.meleeDelay);
        }

        grunt.hasMeleed = false;
    }
}
