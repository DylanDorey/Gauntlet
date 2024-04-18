using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [Range(1f, 10f)]
    [SerializeField]
    private float swordSpeed;

    [Range(1f, 10f)]
    public float swordDamage;

    private float rotateSpeed = 10f;

    public Vector3 moveDirection;

    private void Start()
    {
        Destroy (gameObject, 4f);
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        move();
        firingSword();
    }

    private void move()
    {
        transform.position  += (moveDirection * (swordSpeed* Time.deltaTime));   
    }

    private void firingSword()
    {
        transform.Rotate(0f, 0f, rotateSpeed);
    }
}
