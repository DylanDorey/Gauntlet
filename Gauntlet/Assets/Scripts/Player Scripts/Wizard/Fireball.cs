using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/11/2024]
 * [A fireball that moves away from the player when shot]
 */

public class Fireball : MonoBehaviour
{
    //fireball variables
    [Range(1f, 15f)]
    [SerializeField]
    private float fireballSpeed;

    [Range(1f, 10f)]
    public float fireballDamage;

    public Vector3 moveDirection;

    private void Start()
    {
        //destroy projectile after 3 seconds
        Destroy(gameObject, 3f);
    }

    private void FixedUpdate()
    {
        //move forward over fixed amount of time
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if it collides with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //make the enemy take damage then destroy the projectile
            collision.gameObject.GetComponent<Enemy>().TakeDamage(fireballDamage);
            Destroy(gameObject);
        }

        //if it collides with a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            //destroy the projectile
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Move forward at a desired speed
    /// </summary>
    private void Move()
    {
        transform.position += (moveDirection * (fireballSpeed * Time.deltaTime));
    }
}
