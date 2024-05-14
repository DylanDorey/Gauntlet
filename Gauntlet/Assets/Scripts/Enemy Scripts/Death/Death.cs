using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : Enemy
{
    public int[] deathPoints = { 1000, 2000, 1000, 4000, 2000, 6000, 8000 };
    private int deathPointsIndex = 0;

    public bool hasSapped;

    public AudioClip deathSpawnSound;
    public AudioClip deathSapSound;

    public PlayerData playerHealth;


    public override void Start()
    {
        base.Start();

        InitializeEnemy(1000, 3f, 5, 1f, 30f);
        gameObject.AddComponent<Sap>();
        enemyBehavior = GetComponent<Sap>();
    }

    private void Update()
    {
        LoopPointIndex();
        enemyPoints = deathPoints[deathPointsIndex];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!hasSapped)
            {
                playerHealth = collision.gameObject.GetComponent<PlayerData>();
                ApplyBehavior(enemyBehavior);
            }
        }

        HitByShot(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopCoroutine(GetComponent<Sap>().StartSap());
            playerHealth = null;
        }
    }

    private void HitByShot(Collision collision)
    {
        if (collision.transform.GetComponent<Axe>())
        {
            GameObject.FindFirstObjectByType<Warrior>().gameObject.GetComponent<PlayerData>().playerScore += 1;
            deathPointsIndex++;
        }
        else if (collision.transform.GetComponent<Fireball>())
        {
            GameObject.FindFirstObjectByType<Wizard>().gameObject.GetComponent<PlayerData>().playerScore += 1;
            deathPointsIndex++;
        }
        else if (collision.transform.GetComponent<Sword>())
        {
            GameObject.FindFirstObjectByType<Valkyrie>().gameObject.GetComponent<PlayerData>().playerScore += 1;
            deathPointsIndex++;
        }
        else if (collision.transform.GetComponent<Arrow>())
        {
            GameObject.FindFirstObjectByType<Elf>().gameObject.GetComponent<PlayerData>().playerScore += 1;
            deathPointsIndex++;
        }
    }

    private void LoopPointIndex()
    {
        if(deathPointsIndex > deathPoints.Length)
        {
            deathPointsIndex = 0;
        }
    }
}
