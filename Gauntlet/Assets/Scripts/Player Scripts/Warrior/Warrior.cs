using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerController
{
    [Range(1f, 10f)]
    public float meleeSpeed;

    public GameObject axeProjectilePrefab;

    public override void OnCollisionEnter(Collision collider)
    {

    }
}
