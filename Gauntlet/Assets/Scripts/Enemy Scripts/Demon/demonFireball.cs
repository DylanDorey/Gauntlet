 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demonFireball : MonoBehaviour
{
    [Range(1f, 10f)]
    [SerializeField]
    private float fireballSpeed = 7f;

    [Range(1f, 10f)]
    public int fireballDamage = 10;

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
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerData>().TakeDamage(fireballDamage);
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.position += (moveDirection * (fireballSpeed * Time.deltaTime));
    }
}
