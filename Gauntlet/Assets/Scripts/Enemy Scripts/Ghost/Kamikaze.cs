using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/16/2024]
 * [The Kamikaze behavior of the Ghost Enemy]
 */

public class Kamikaze : MonoBehaviour, IEnemyBehavior
{
    //the player collider that the ghost collided with
    public Collision collision;

    public void Behavior(Enemy enemy)
    {
        //start Kamikaze behavior
        InitiateKamikaze(enemy);
    }

    /// <summary>
    /// Deals damage to the player on contact
    /// </summary>
    /// <param name="enemy"> the enemy that is implementing the IEnemyBehavior </param>
    private void InitiateKamikaze(Enemy enemy)
    {
        //remove health from the player
        collision.gameObject.GetComponent<PlayerData>().TakeDamage(GetComponent<Enemy>().enemyDamage);

        //call on death method
        GetComponent<Ghost>().OnDeath();
    }
}
