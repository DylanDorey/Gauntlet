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

    public GameObject warriorPrefab;
    public GameObject axePrefab;
    public Transform axeSpawnPos;

    public void Start()
    {
        warriorPrefab = GetComponent<PlayerController>().characterPrefabs[0];
        axePrefab = GetComponent<PlayerController>().projectilePrefabs[0];

        GameObject warrior = Instantiate(warriorPrefab, transform.position, Quaternion.identity);
        warrior.transform.parent = GetComponent<PlayerController>().gameObject.transform;

        axeSpawnPos = warrior.transform.GetChild(2);

        GetComponent<PlayerData>().InitializePlayerData(700f, 0f, 0f, 0f, 5f, true);
        GetComponent<PlayerController>().shootBehavior = GetComponent<ThrowAxe>();
        GetComponent<PlayerController>().meleeBehavior = GetComponent<WarriorMelee>();
    }

    private void Update()
    {
        rayDirection = transform.GetChild(0).transform.forward;
    }
}
