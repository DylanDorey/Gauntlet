using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Enemy
{
    private int targetPointValue;

    private void Start()
    {
        InitializeEnemy(500, 5f, 10, 10f, 10f);

        gameObject.AddComponent<Steal>();
        enemyBehavior = GetComponent<Steal>();

        //initialize the target pos to a random player
        targetPos = GameObject.Find("Player").gameObject.transform.position;
    }

    private void Update()
    {
        FindRichestPlayer();
    }

    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<PlayerController>())
        {
            GetComponent<Steal>().playerInventory = collision.transform.GetComponent<InventoryManager>();
            GetComponent<Steal>().playerData = collision.transform.GetComponent<PlayerData>();

            collision.transform.GetComponent<PlayerData>().playerHealth -= enemyDamage;
            ApplyBehavior(enemyBehavior);
        }
    }

    /// <summary>
    /// Finds the richest player on the level
    /// </summary>
    private void FindRichestPlayer()
    {
        Collider newCollider = GetComponentInChildren<AttackRadius>().collide;
        int collidedPoints;

        if (newCollider != null)
        {
            if (newCollider.GetComponent<PlayerController>())
            {
                collidedPoints = newCollider.GetComponent<PlayerData>().playerScore;

                if (collidedPoints > targetPointValue)
                {
                    targetPointValue = collidedPoints;

                    targetPos = newCollider.transform.position;
                }
            }
        }
    }
}
