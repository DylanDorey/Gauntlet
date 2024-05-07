using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Bson;
using UnityEngine;

public class Ghost : Enemy
{
    private void Start()
    {
        InitializeEnemy(20, 3f, 10, 5, 10f);

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
    }
}
