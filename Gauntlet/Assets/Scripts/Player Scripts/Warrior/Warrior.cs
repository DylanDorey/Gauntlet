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
    //delay before being able to melee again
    [Range(1f, 10f)]
    public float meleeDelay;

    //delay before being able to throw another projectile
    [Range(1f, 10f)]
    public float throwDelay;

    //the damage each melee does
    [Range(1f, 10f)]
    public int meleeDamage;

    //the distance at which the character can melee
    [Range(1f, 10f)]
    public float meleeDistance = 1f;

    //raycast variables
    public RaycastHit hit;
    public Vector3 rayDirection;

    //prefabs
    public GameObject warriorPrefab;
    public GameObject axePrefab;
    public Transform axeSpawnPos;

    //audio clips
    public AudioClip axeThrowSound;
    public AudioClip meleeSound;
    public AudioClip hurtSound;

    public void Start()
    {
        //store player controller reference in variable
        PlayerController playerController = GetComponent<PlayerController>();

        //set projectile spawn pos
        axeSpawnPos = transform.GetChild(0).transform.GetChild(2);

        //initialize player data and shooting/melee behavior
        GetComponent<PlayerData>().InitializePlayerData(700, 0, 1f, 1, 7f, true);
        playerController.shootBehavior = GetComponent<ThrowAxe>();
        playerController.meleeBehavior = GetComponent<WarriorMelee>();

        //initialize audio clips
        axeThrowSound = playerController.warriorAudioClips[0];
        meleeSound = playerController.warriorAudioClips[1];
        hurtSound = playerController.warriorAudioClips[2];

        //link Warrior ui panel to this player data
        UIManager.Instance.warrior = GetComponent<PlayerData>();
    }

    private void Update()
    {
        //set the players forward direction at all times
        rayDirection = transform.GetChild(0).transform.forward;
    }
}
