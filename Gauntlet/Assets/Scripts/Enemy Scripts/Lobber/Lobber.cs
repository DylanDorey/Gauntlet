using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Diaz, Ismael]
 * Last Updated: 5/9/24
 * [Functions for Lobber]
 */

public class Lobber : Enemy
{
    public GameObject projectilePrefab;
    public Transform throwPoint;
    public float throwForce = 10f;
    public float throwDelay = 2f;

    private bool canThrow = true;

    private void FixedUpdate()
    {
        if (isAggro)
        {
            FindNearestPlayer();
            Move();
            if (canThrow)
            {
                StartCoroutine(ThrowProjectileWithDelay());
            }
        }
    }

    IEnumerator ThrowProjectileWithDelay()
    {
        canThrow = false;
        yield return new WaitForSeconds(throwDelay);

        // Calculate the direction towards the player
        Vector3 directionToPlayer = (targetPos - throwPoint.position).normalized;

        // Create and throw the projectile
        GameObject projectile = Instantiate(projectilePrefab, throwPoint.position, Quaternion.identity);

        canThrow = true;
    }

    void FindNearestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        float minDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;

        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestPlayer = player;
            }
        }

        if (nearestPlayer != null && minDistance <= enemyRadius)
        {
            targetPos = nearestPlayer.transform.position;
        }
        else
        {
            targetPos = Vector3.zero;
        }
    }
}
