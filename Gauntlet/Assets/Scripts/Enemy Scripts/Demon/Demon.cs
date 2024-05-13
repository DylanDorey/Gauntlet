using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: [Diaz, Ismael]
 * Last Updated: [5/2/24]
 * [Demon Attributes]
 */
public class Demon : Enemy
{
    private readonly float meleeDistance = 3f;
    public float meleeDelay = 2f;
    private Vector3 rayDirection;
    public RaycastHit hit;
    public bool hasMeleed;

    public override void Start()
    {
        base.Start();

        InitializeEnemy(10, 2f, 5, 5, 10f);
        gameObject.AddComponent<GruntMelee>();
        enemyBehavior = GetComponent<GruntMelee>();

        gameObject.AddComponent<demonShoot>();
        //enemyBehavior = GetComponent<demonShoot>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (enemyHealth <= 0)
        {
            if (collision.transform.GetComponent<Axe>() || collision.transform.GetComponent<Fireball>() || collision.transform.GetComponent<Sword>())
            {
                UIManager.Instance.warrior.gameObject.GetComponent<PlayerData>().playerScore += PassPoints();
            }
        }
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