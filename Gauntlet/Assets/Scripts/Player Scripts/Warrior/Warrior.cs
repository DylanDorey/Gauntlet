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
    public float meleeDistance = 1f;

    public RaycastHit hit;
    public Vector3 rayDirection;

    public GameObject warriorPrefab;
    public GameObject axePrefab;
    public Transform axeSpawnPos;

    public AudioClip axeThrowSound;
    public AudioClip meleeSound;
    public AudioClip hurtSound;

    public void Start()
    {
        PlayerController playerController = GetComponent<PlayerController>();

        //warriorPrefab = playerController.characterPrefabs[0];
        //axePrefab = playerController.projectilePrefabs[0];

        ////axeSpawnPos = warrior.transform.GetChild(2);
        axeSpawnPos = transform.GetChild(0).transform.GetChild(2);

        GetComponent<PlayerData>().InitializePlayerData(700, 0, 1f, 1, 8f, true);
        playerController.shootBehavior = GetComponent<ThrowAxe>();
        playerController.meleeBehavior = GetComponent<WarriorMelee>();

        axeThrowSound = playerController.warriorAudioClips[0];
        meleeSound = playerController.warriorAudioClips[1];
        hurtSound = playerController.warriorAudioClips[2];

        UIManager.Instance.warrior = GetComponent<PlayerData>();
    }

    private void Update()
    {
        rayDirection = transform.GetChild(0).transform.forward;
    }
}
