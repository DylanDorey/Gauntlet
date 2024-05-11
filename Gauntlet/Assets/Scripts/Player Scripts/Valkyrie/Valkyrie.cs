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

    public AudioClip throwSwordSound;
    public AudioClip valkyrieMeleeSound;
    public AudioClip valkyrieHurt;

    public void Start()
    {
        PlayerController playerController = GetComponent<PlayerController>();

        valkyriePrefab = playerController.characterPrefabs[1];
        swordPrefab = playerController.projectilePrefabs[1];

        swordSpawnpos = transform.GetChild(0).transform.GetChild(0);

        GetComponent<PlayerData>().InitializePlayerData(700, 0, 2f, 3, 8f, true);
        playerController.shootBehavior = GetComponent<throwSword>();
        playerController.meleeBehavior = GetComponent<swordMelee>();

        throwSwordSound = playerController.valkyrieAudioClips[0];
        valkyrieMeleeSound = playerController.valkyrieAudioClips[1];
        valkyrieHurt = playerController.valkyrieAudioClips[2];

        UIManager.Instance.valkyrie = GetComponent<PlayerData>();
    }

    private void Update()
    {
        hitPoint = transform.GetChild(0).transform.forward;
    }
}
