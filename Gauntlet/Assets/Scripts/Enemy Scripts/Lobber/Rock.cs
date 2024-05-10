using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [Range(1f, 10f)]
    [SerializeField]
    private float rockSpeed = 7f;

    [Range(1f, 10f)]
    public float rockDamage = 3f;

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
            collision.gameObject.GetComponent<PlayerData>().TakeDamage(rockDamage);
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.position += (moveDirection * (rockSpeed * Time.deltaTime));
    }
}
