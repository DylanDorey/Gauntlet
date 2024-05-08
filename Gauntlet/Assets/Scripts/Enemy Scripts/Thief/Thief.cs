using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Enemy
{
    public AudioClip thiefTone;
    private int targetPointValue;

    public bool hasStolen = false;
    public bool hasDied = false;

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
        if (!hasStolen)
        {
            FindRichestPlayer();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<PlayerController>())
        {
            GetComponent<Steal>().playerInventory = collision.transform.GetComponent<InventoryManager>();
            GetComponent<Steal>().playerData = collision.transform.GetComponent<PlayerData>();

            collision.transform.GetComponent<PlayerData>().playerHealth -= enemyDamage;

            if (!hasStolen)
            {
                ApplyBehavior(enemyBehavior);
            }
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

                    AudioManager.Instance.AddToSoundQueue(thiefTone);
                }
            }
        }
    }

    public override void OnDeath()
    {
        if (hasStolen)
        {
            Instantiate(GetComponent<Steal>().stolenItem, transform.position, Quaternion.identity);
        }

        hasDied = true;

        base.OnDeath();
    }

    public IEnumerator Flee()
    {
        for (int index = 0; index < 1; index++)
        {
            yield return new WaitForSeconds(5f);
        }

        hasDied = false;

        if (GetComponent<Steal>().stolenItem != null)
        {
            LevelManager.Instance.thiefItem = GetComponent<Steal>().stolenItem;
        }

        gameObject.SetActive(false);
    }
}
