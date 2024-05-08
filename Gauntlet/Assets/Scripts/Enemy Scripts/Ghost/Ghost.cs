using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Bson;
using UnityEngine;

public class Ghost : Enemy
{
    private void Start()
    {
        InitializeEnemy(20, 2.5f, 10, 5, 10f);

        gameObject.AddComponent<Kamikaze>();
        enemyBehavior = GetComponent<Kamikaze>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            GetComponent<Kamikaze>().collision = collision;
            ApplyBehavior(enemyBehavior);

            Destroy(gameObject);
        }

        if (enemyHealth <= 0)
        {
            if (collision.transform.GetComponent<Axe>() || collision.transform.GetComponent<Fireball>() || collision.transform.GetComponent<Sword>())
            {
                UIManager.Instance.warrior.gameObject.GetComponent<PlayerData>().playerScore += PassPoints();
            }
        }
    }
}
