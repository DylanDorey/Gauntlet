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
    public float throwDelay = 2f;
    public AudioClip throwSound;

    private bool canThrow = true;

    private void Start()
    {
        InitializeEnemy(20, 3f, 0, 10f, 10f);
    }

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

    public void OnCollisionEnter(Collision collision)
    {
        if (enemyHealth <= 0)
        {
            if (collision.transform.GetComponent<Axe>() || collision.transform.GetComponent<Fireball>() || collision.transform.GetComponent<Sword>())
            {
                UIManager.Instance.warrior.gameObject.GetComponent<PlayerData>().playerScore += PassPoints();
                OnDeath();
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
        projectile.GetComponent<Rock>().moveDirection = transform.forward;
        AudioManager.Instance.AddToSoundQueue(throwSound);

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
