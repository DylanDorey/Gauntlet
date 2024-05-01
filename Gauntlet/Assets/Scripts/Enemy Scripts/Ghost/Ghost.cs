using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Bson;
using UnityEngine;

public class Ghost : Enemy
{
    private void Start()
    {
        InitializeEnemy(20, 3f, 10, 5, 2f);

        gameObject.AddComponent<Kamikaze>();
        enemyBehavior = GetComponent<Kamikaze>();
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        if (collision.gameObject.GetComponent<PlayerController>())
        {
            ApplyBehavior(enemyBehavior);
        }
    }
}
