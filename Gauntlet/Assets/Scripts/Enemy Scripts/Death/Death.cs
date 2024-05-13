using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : Enemy
{
    public int[] deathPoints = { 1000, 2000, 1000, 4000, 2000, 6000, 8000 };
    private int hitCounter = 0;

    private int currentHealth;
    private void Start()
    {
        currentHealth = Mathf.RoundToInt(enemyHealth);
        InitializeEnemy(1000, 3f, 5, 100, 10f);
        ApplyBehavior(enemyBehavior);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ApplyBehavior(enemyBehavior);
        }


    }
    public void takeDamage(float amount)
    {
        enemyHealth -= amount;

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void HitByShot()
    {
        int points = deathPoints[hitCounter];
        //GameManager.Instance.AddPoints(points);
        takeDamage(1);
    }

    public void UsePotion()
    {
        hitCounter = 0;

        Destroy(gameObject);
    }

}
