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

        elfPrefab = playerController.characterPrefabs[0];
        arrowPrefab = playerController.projectilePrefabs[0];

        GameObject elf = Instantiate(elfPrefab, transform.position, Quaternion.identity);
        elf.transform.parent = playerController.gameObject.transform;

        //arrowPrefab = elf.transform.GetChild(index);

        GetComponent<PlayerData>().InitializePlayerData(700f, 0, 1f, 1f, 8f, true);
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