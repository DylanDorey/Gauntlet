using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [Range(1f, 15f)]
    [SerializeField]
    private float swordSpeed;

    [Range(1f, 10f)]
    public float swordDamage;

    private readonly float rotateSpeed = 10f;

    public Vector3 moveDirection;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(swordDamage);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Destroy (gameObject, 4f);
    }

    private void FixedUpdate()
    {
        Move();
        FiringSword();
    }

    private void Move()
    {
        transform.position  += (moveDirection * (swordSpeed* Time.deltaTime));   
    }

    private void FiringSword()
    {
        transform.Rotate(0f, rotateSpeed, 0f);
    }
}
