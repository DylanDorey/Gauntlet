using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : Enemy
{
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        InitializeEnemy(100, 5f, 20, 100f, 2f);
    }

    public override void Move()
    {
        TurnTowardsPlayer();
    }

    private void TurnTowardsPlayer()
    {
        if (playerTransform != null)
        {
            targetPos = playerTransform.position;
            transform.LookAt(targetPos);
        }
    }

    public override void OnDeath()
    {
        Destroy(gameObject); // Destroy the enemy object
    }
}
