using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/18/2024]
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

    public virtual void OnCollisionEnter(Collision collision)
    {
        
    }

    private void FixedUpdate()
    {
        if (isAggro)
        {
            Move();
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
        enemyDamage = damage;
        enemyHealth = health;
        enemyRadius = radius;

        transform.GetComponentInChildren<SphereCollider>().radius = enemyRadius;
    }

    public virtual void Move()
    {
        transform.LookAt(targetPos);
        transform.Translate(Vector3.forward * (enemySpeed * Time.deltaTime));
    }

    public int PassPoints()
    {
        return enemyPoints;
    }

    public void TakeDamage(float amount)
    {
        enemyHealth -= amount;
    }

    public virtual void OnDeath()
    {
        
    }

    public void ApplyBehavior(IEnemyBehavior behavior)
    {
        behavior.Behavior(this);
    }
}
