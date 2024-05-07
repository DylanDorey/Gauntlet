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
    [Range(1f, 10f)]
    [SerializeField]
    private float fireballSpeed;

    [Range(1f, 10f)]
    public float fireballDamage;

    public Vector3 moveDirection;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(fireballDamage);
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.position += (moveDirection * (fireballSpeed * Time.deltaTime));
    }
}
