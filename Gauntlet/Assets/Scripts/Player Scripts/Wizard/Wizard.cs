using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/11/2024]
 * [Wizard class for the character Merlin]
 */

public class Wizard : MonoBehaviour
{
    [Range(1f, 10f)]
    public float throwDelay;

    public RaycastHit hit;
    public Vector3 rayDirection;

    public GameObject fireballPrefab;
    public Transform fireballSpawnPos;

    public void Start()
    {
        GetComponent<PlayerController>().shootBehavior = GetComponent<ThrowFireball>();
        GetComponent<PlayerData>().InitializePlayerData(700f, 2f, 0f, 3f);
    }

    private void Update()
    {
        rayDirection = transform.GetChild(0).transform.forward;
    }
}
