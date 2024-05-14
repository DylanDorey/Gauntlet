using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Bson;
using UnityEngine;

public class Ghost : Enemy
{
    public override void Start()
    {
        base.Start();

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
        }

        if (enemyHealth <= 0)
        {
            if (collision.transform.GetComponent<Axe>() || collision.transform.GetComponent<Fireball>() || collision.transform.GetComponent<Sword>() || collision.transform.GetComponent<Arrow>())
            {
                UIManager.Instance.warrior.gameObject.GetComponent<PlayerData>().playerScore += PassPoints();
            }
        }
    }
}
