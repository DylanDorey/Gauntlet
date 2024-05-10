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
        PlayerController playerController = GetComponent<PlayerController>();

        wizardPrefab = playerController.characterPrefabs[2];
        fireballPrefab = playerController.projectilePrefabs[2];

        GameObject wizard = Instantiate(wizardPrefab, transform.position, Quaternion.identity);
        wizard.transform.parent = playerController.gameObject.transform;

        fireballSpawnPos = transform.GetChild(0).transform.GetChild(2);

        GetComponent<PlayerData>().InitializePlayerData(700, 0, 4f, 1, 5f, false);
        playerController.shootBehavior = GetComponent<ThrowFireball>();

        UIManager.Instance.wizard = GetComponent<PlayerData>();
    }
}
