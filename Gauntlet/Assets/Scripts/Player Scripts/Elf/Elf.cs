using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : MonoBehaviour
{
    [Range(1f, 10f)]
    public float meleeDelay;

    [Range(1f, 10f)]
    public float throwDelay;

    public RaycastHit hit;
    public Vector3 rayDirection;

    public GameObject elfPrefab;
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;

    public AudioClip arrowShootSound;
    public AudioClip hurtSound;

    private void Start()
    {
        PlayerController playerController = GetComponent<PlayerController>();

        elfPrefab = playerController.characterPrefabs[3];
        arrowPrefab = playerController.projectilePrefabs[3];

        arrowSpawnPoint = transform.GetChild(0).transform.GetChild(2);

        GetComponent<PlayerData>().InitializePlayerData(700, 0, 1f, 1, 10f, true);
        playerController.shootBehavior = GetComponent<arrowShoot>();

        arrowShootSound = playerController.warriorAudioClips[0];
        hurtSound = playerController.warriorAudioClips[2];

        UIManager.Instance.elf = GetComponent<PlayerData>();
    }
    private void Update()
    {
        rayDirection = transform.GetChild(0).transform.forward;
    }

}