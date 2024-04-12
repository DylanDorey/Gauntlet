using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/11/2024]
 * [Warrior class for the character Thor]
 */

public class Warrior : MonoBehaviour
{
    [Range(1f, 10f)]
    public float meleeDelay;

    [Range(1f, 10f)]
    public float throwDelay;

    [Range(1f, 10f)]
    public int meleeDamage;

    [Range(1f, 10f)]
    public float meleeDistance = 0.2f;

    public RaycastHit hit;
    public Vector3 rayDirection;

    public GameObject axePrefab;
    public Transform axeSpawnPos;

    public void Start()
    {
        GetComponent<PlayerController>().meleeBehavior = GetComponent<WarriorMelee>();
        GetComponent<PlayerController>().shootBehavior = GetComponent<ThrowAxe>();
    }

    private void Update()
    {
        rayDirection = transform.GetChild(0).transform.forward;
    }

    public void OnCollisionEnter(Collision collider)
    {

    }
}
