using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerController, IMeleeBehavior
{

    [Range(1f, 10f)]
    public float meleeSpeed;

    [Range(0f, 10f)]
    public int meleeAttack;

    public RaycastHit hit;
    public Vector3 rayDirection;
    public float meleeDistance = 10f;

    public GameObject axeProjectilePrefab;

    private void Start()
    {
        rayDirection = Vector3.forward;
    }

    private void Update()
    {
        //draw our laser
        Debug.DrawRay(transform.position, rayDirection, Color.red);
    }

    public override void OnCollisionEnter(Collision collider)
    {

    }

    public void MeleeBehavior(PlayerController player)
    {
        StartCoroutine(Melee());
    }

    /// <summary>
    /// allows the player to hit directly in front of them
    /// </summary>
    public IEnumerator Melee()
    {
        while (true)
        {
            if (Physics.Raycast(transform.position, rayDirection, out hit, meleeDistance))
            {
                Debug.DrawRay(transform.position, rayDirection, Color.green);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
