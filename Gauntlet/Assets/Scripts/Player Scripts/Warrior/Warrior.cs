using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    [Range(1f, 10f)]
    public float meleeDelay;

    [Range(0f, 10f)]
    public int meleeAttack;

    public RaycastHit hit;
    public Vector3 rayDirection;
    public float meleeDistance = 10f;

    public void Start()
    {
        GetComponent<PlayerController>().meleeBehavior = gameObject.AddComponent<WarriorMelee>();
        rayDirection = Vector3.forward;
    }

    private void Update()
    {

    }

    public void OnCollisionEnter(Collision collider)
    {

    }
}
