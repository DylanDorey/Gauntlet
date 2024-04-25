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

    public GameObject wizardPrefab;
    public GameObject fireballPrefab;
    public Transform fireballSpawnPos;

    public void Start()
    {
        wizardPrefab = GetComponent<PlayerController>().characterPrefabs[2];
        fireballPrefab = GetComponent<PlayerController>().projectilePrefabs[2];

        GameObject wizard = Instantiate(wizardPrefab, transform.position, Quaternion.identity);
        wizard.transform.parent = GetComponent<PlayerController>().gameObject.transform;

        fireballSpawnPos = wizard.transform.GetChild(2);

        GetComponent<PlayerData>().InitializePlayerData(700f, 0f, 2f, 0f, 3f, false);
        GetComponent<PlayerController>().shootBehavior = GetComponent<ThrowFireball>();
    }
}
