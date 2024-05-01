using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : MonoBehaviour, IEnemyBehavior
{
    public void Behavior(Enemy enemy)
    {
        InitiateKamikaze(enemy);
    }

    private void InitiateKamikaze(Enemy enemy)
    {

    }
}
