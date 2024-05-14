using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : Enemy
{
    public int[] deathPoints = { 1000, 2000, 1000, 4000, 2000, 6000, 8000 };
    private int hitCounter = 0;

    public bool hasSapped;

    public AudioClip deathSpawnSound;
    public AudioClip deathSapSound;

    public override void Start()
    {
        InitializeEnemy(1000, 3f, 5, 100f, 30f);
        gameObject.AddComponent<Sap>();
        enemyBehavior = GetComponent<Sap>();
        targetPos = GameObject.FindAnyObjectByType<PlayerController>().transform.position;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!hasSapped)
            {
                ApplyBehavior(enemyBehavior);
            }
        }
    }

    public void HitByShot()
    {
        int points = deathPoints[hitCounter];
        //GameManager.Instance.AddPoints(points);
        TakeDamage(1);
    }

    public void UsePotion()
    {
        hitCounter = 0;

        OnDeath();
    }
}
