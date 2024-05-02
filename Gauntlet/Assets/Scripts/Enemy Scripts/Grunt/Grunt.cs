using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : Enemy
{
    private readonly float meleeDistance = 3f;
    public float meleeDelay = 3f;
    private Vector3 rayDirection;
    public RaycastHit hit;
    public bool hasMeleed = false;

    private void Start()
    {
        InitializeEnemy(10, 2f, 5, 5, 2f);

        gameObject.AddComponent<GruntMelee>();
        enemyBehavior = GetComponent<GruntMelee>();
    }

    private void Update()
    {
        rayDirection = transform.forward;

        if (Physics.Raycast(transform.position, rayDirection, out hit, meleeDistance))
        {
            if (hit.transform.GetComponent<PlayerController>() && !hasMeleed)
            {
                ApplyBehavior(enemyBehavior);
            }
        }
        else
        {
            hasMeleed = false;
        }
    }
}
