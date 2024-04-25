using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Diaz, Ismael]
 * Last Updated: 4/18/24
 * [Core class for Valkyrie]
 */

public class Valkyrie : MonoBehaviour
{
    [Range(1f, 10f)]
    public float swingDelay;

    [Range(1f, 10f)]
    public float swingSpeed;

    [Range(1f, 10f)]
    public float throwDelay;

    [Range(1f, 10f)]
    public int swingDamage;

    [Range(1f, 10f)]
    public float meleeDistance = 0.2f;

    public RaycastHit hit;
    public Vector3 hitPoint;

    public GameObject valkyriePrefab;
    public GameObject swordPrefab;
    public Transform swordSpawnpos;

    public void Start()
    {
        valkyriePrefab = GetComponent<PlayerController>().characterPrefabs[2];
        swordPrefab = GetComponent<PlayerController>().projectilePrefabs[2];

        GameObject valkyrie = Instantiate(valkyriePrefab, transform.position, Quaternion.identity);
        valkyrie.transform.parent = GetComponent<PlayerController>().gameObject.transform;

        swordSpawnpos = valkyrie.transform.GetChild(0);

        GetComponent<PlayerData>().InitializePlayerData(700f, 0f, 0f, 5f, true);
        GetComponent<PlayerController>().shootBehavior = GetComponent<throwSword>();
        GetComponent<PlayerController>().meleeBehavior = GetComponent<swordMelee>();
    }

    private void Update()
    {
        hitPoint = transform.GetChild(0).transform.forward;
    }
}
