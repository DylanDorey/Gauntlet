using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Range(1f, 15f)]
    [SerializeField]
    private float arrowSpeed;

    [Range(1f, 10f)]
    public float arrowDamage;

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
            collision.gameObject.GetComponent<Enemy>().TakeDamage(arrowDamage);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.position += (moveDirection * (arrowSpeed * Time.deltaTime));
    }
}
