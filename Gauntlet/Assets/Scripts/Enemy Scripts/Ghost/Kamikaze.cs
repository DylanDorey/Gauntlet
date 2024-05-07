using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : MonoBehaviour, IEnemyBehavior
{
    public Collision collision;

    public void Behavior(Enemy enemy)
    {
        InitiateKamikaze(enemy);
    }

    private void InitiateKamikaze(Enemy enemy)
    {
        collision.gameObject.GetComponent<PlayerData>().TakeDamage(GetComponent<Enemy>().enemyDamage);

        Destroy(gameObject);
    }
}
