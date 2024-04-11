using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    [Range(1f, 10f)]
    public float meleeDelay;

    [Range(1f, 10f)]
    public int meleeDamage;

    [Range(1f, 10f)]
    public float meleeDistance = 0.2f;

    public RaycastHit hit;
    public Vector3 rayDirection;

    public void Start()
    {
        GetComponent<PlayerController>().meleeBehavior = GetComponent<WarriorMelee>();
        rayDirection = Vector3.forward;
    }

    public void OnCollisionEnter(Collision collider)
    {

    }
}
