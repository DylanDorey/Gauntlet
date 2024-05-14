using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/13/2024]
 * [Base Enemy class]
 */

public class Enemy : MonoBehaviour
{
    //Enemy values
    public bool isAggro;
    public int enemyPoints;
    public int enemyLevel;
    public int enemyDamage;
    public float enemyHealth;
    public float enemySpeed;
    public float enemyRadius;

    public Vector3 targetPos;
    public IEnemyBehavior enemyBehavior;

    public virtual void Start()
    {
        //add the enemy to the active enemies list
        LevelManager.Instance.activeEnemies.Add(gameObject);
    }

    private void FixedUpdate()
    {
        //if is aggro move to the target pos
        if (isAggro)
        {
            Move();
        }

        //if the enemy is above or below the map, reset to proper height
        if (transform.position.y < 0.1f|| transform.position.y > 0.5f)
        {
            transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
        }
    }

    /// <summary>
    /// Initializes enemy values
    /// </summary>
    /// <param name="points"> how many points the enemy is worth </param>
    /// <param name="level"> the level of the enemy based on the generator </param>
    /// <param name="speed"> how fast the enemy will move </param>
    /// <param name="damage"> how hard the enemy can damage the player </param>
    /// <param name="health"> the enemey's amount of health </param>
    /// <param name="radius"> the attack radius of the enemy </param>
    public void InitializeEnemy(int points, float speed, int damage, float health, float radius)
    {
        enemyPoints = points;
        enemySpeed = speed;

        if(enemyLevel == 0)
        {
            enemyLevel = 1;
        }

        enemyDamage = damage * enemyLevel;
        enemyHealth = health * enemyLevel;
        enemyRadius = radius;

        if (!transform.GetComponent<Thief>())
        {
            transform.GetComponentInChildren<SphereCollider>().radius = enemyRadius;
        }
    }

    /// <summary>
    /// Allows the enemy to move towards a target position
    /// </summary>
    public virtual void Move()
    {
        transform.LookAt(targetPos);
        transform.Translate(Vector3.forward * (enemySpeed * Time.deltaTime));
    }


    /// <summary>
    /// Passes points to whomever requests it
    /// </summary>
    /// <returns> the enemy point value </returns>
    public int PassPoints()
    {
        return enemyPoints;
    }

    /// <summary>
    /// Removes health from enemy
    /// </summary>
    /// <param name="amount"> the amount of incoming damage </param>
    public void TakeDamage(float amount)
    {
        //if the enemy is not death
        if (transform != GetComponent<Death>())
        {
            //remove health
            enemyHealth -= amount;
        }

        //if the enemy has not health left and is not death
        if (enemyHealth <= 0 && !transform.GetComponent<Death>())
        {
            //call on death method
            OnDeath();
        }
    }

    /// <summary>
    /// Removes enemy when dead
    /// </summary>
    public virtual void OnDeath()
    {
        //set active to false
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Applies the enemies behavior
    /// </summary>
    /// <param name="behavior"> the enemies unique behavior </param>
    public void ApplyBehavior(IEnemyBehavior behavior)
    {
        behavior.Behavior(this);
    }
}
