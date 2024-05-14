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
    //delay before being able to throw another projectile
    [Range(1f, 10f)]
    public float throwDelay;

    //prefabs
    public GameObject wizardPrefab;
    public GameObject fireballPrefab;

    //projectile spawn point
    public Transform fireballSpawnPos;

    //wizard audio clips
    public AudioClip throwFireballSound;
    public AudioClip wizardHurt;

    public void Start()
    {
        //store player controller reference in variable
        PlayerController playerController = GetComponent<PlayerController>();

        //intialize prefabs
        wizardPrefab = playerController.characterPrefabs[2];
        fireballPrefab = playerController.projectilePrefabs[2];

        //set projectile spawn pos
        fireballSpawnPos = transform.GetChild(0).transform.GetChild(2);

        //initialize player data and shooting behavior
        GetComponent<PlayerData>().InitializePlayerData(700, 0, 4f, 1, 5f, false);
        playerController.shootBehavior = GetComponent<ThrowFireball>();

        //initialize audio clips
        throwFireballSound = playerController.wizardAudioClips[0];
        wizardHurt = playerController.wizardAudioClips[1];

        //link Wizard ui panel to this player data
        UIManager.Instance.wizard = GetComponent<PlayerData>();
    }
}
