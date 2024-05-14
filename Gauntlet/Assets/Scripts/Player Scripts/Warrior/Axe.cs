using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/11/2024]
 * [A throwable axe that the warrior can throw]
 */

public class Axe : MonoBehaviour
{
    //axe variables
    [Range(1f, 15f)]
    [SerializeField]
    private float axeSpeed;

    [Range(1f, 10f)]
    public float axeDamage;

    private readonly float rotateSpeed = 10f;

    public Vector3 moveDirection;

    private void Start()
    {
        //destroy the axe after 3 seconds
        Destroy(gameObject, 3f);
    }

    private void FixedUpdate()
    {
        //move and rotate the axe over a fixed amount of time
        Move();
        RotateAxe();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if it collides with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //remove health from the enemy and destroy the axe
            collision.gameObject.GetComponent<Enemy>().TakeDamage(axeDamage);
            Destroy(gameObject);
        }

        //if it collides with a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            //destroy the axe
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Moves the axe forward at a certain speed
    /// </summary>
    private void Move()
    {
        transform.position += (moveDirection * (axeSpeed * Time.deltaTime));
    }

    /// <summary>
    /// Rotates the axe at a certain speed while moving
    /// </summary>
    private void RotateAxe()
    {
        transform.Rotate(0f, 0f, rotateSpeed);
    }
}
