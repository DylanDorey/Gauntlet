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
    [Range(1f, 10f)]
    [SerializeField]
    private float axeSpeed;

    [Range(1f, 10f)]
    public float axeDamage;

    private float rotateSpeed = 10f;

    public Vector3 moveDirection;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void FixedUpdate()
    {
        Move();
        RotateAxe();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //collision.gameObject.GetComponent<Enemy>().TakeDamage(axeDamage);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.position += (moveDirection * (axeSpeed * Time.deltaTime));
    }

    private void RotateAxe()
    {
        transform.Rotate(0f, 0f, rotateSpeed);
    }
}
