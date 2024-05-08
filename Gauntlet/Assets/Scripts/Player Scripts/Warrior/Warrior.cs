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

    public AudioClip axeThrowSound;
    public AudioClip meleeSound;

    public void Start()
    {
        PlayerController playerController = GetComponent<PlayerController>();

        warriorPrefab = playerController.characterPrefabs[0];
        axePrefab = playerController.projectilePrefabs[0];

        GameObject warrior = Instantiate(warriorPrefab, transform.position, Quaternion.identity);
        warrior.transform.parent = playerController.gameObject.transform;

        axeSpawnPos = warrior.transform.GetChild(2);

        GetComponent<PlayerData>().InitializePlayerData(700f, 0, 1f, 1f, 8f, true);
        playerController.shootBehavior = GetComponent<ThrowAxe>();
        playerController.meleeBehavior = GetComponent<WarriorMelee>();

        axeThrowSound = playerController.warriorAudioClips[0];

        UIManager.Instance.warrior = GetComponent<PlayerData>();
    }

    private void Update()
    {
        rayDirection = transform.GetChild(0).transform.forward;
    }
}
