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

    public void Start()
    {
        PlayerController playerController = GetComponent<PlayerController>();

        valkyriePrefab = playerController.characterPrefabs[1];
        swordPrefab = playerController.projectilePrefabs[1];

        //GameObject valkyrie = Instantiate(valkyriePrefab, transform.position, Quaternion.identity);
        //valkyrie.transform.parent = playerController.gameObject.transform;

        swordSpawnpos = transform.GetChild(0).transform.GetChild(0);

        GetComponent<PlayerData>().InitializePlayerData(700f, 0, 1f, 3f, 8f, true);
        playerController.shootBehavior = GetComponent<throwSword>();
        playerController.meleeBehavior = GetComponent<swordMelee>();

        UIManager.Instance.valkyrie = GetComponent<PlayerData>();
    }

    private void Update()
    {
        hitPoint = transform.GetChild(0).transform.forward;
    }
}
