using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonMelee : MonoBehaviour, IEnemyBehavior
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
        Demon demon = enemy.GetComponent<Demon>();
        demon.hasMeleed = true;

        for (int index = 0; index < 1; index++)
        {
            demon.playerCollision.gameObject.GetComponent<PlayerData>().TakeDamage(demon.enemyDamage);
            yield return new WaitForSeconds(demon.meleeDelay);
        }

        demon.hasMeleed = false;
    }
}
