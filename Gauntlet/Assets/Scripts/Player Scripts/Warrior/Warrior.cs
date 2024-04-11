using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerController
{

    [Range(1f, 10f)]
    public float meleeSpeed;

    [Range(0f, 10f)]
    public int meleeAttack;

    public RaycastHit hit;
    public Vector3 rayDirection;
    public float meleeDistance = 10f;

    public GameObject axeProjectilePrefab;

    private void Start()
    {
        rayDirection = Vector3.forward;
    }

    private void Update()
    {
        //draw our laser
        Debug.DrawRay(transform.position, rayDirection, Color.red);
    }

    public override void OnCollisionEnter(Collision collider)
    {

    }
}
