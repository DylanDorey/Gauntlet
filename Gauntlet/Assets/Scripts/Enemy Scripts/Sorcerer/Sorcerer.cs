using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorcerer : Enemy
{
    private bool hasMeleed = false;
    private bool inMeleeDistance = false;
    private float meleeDelay = 3f;

    private void Start()
    {
        InitializeEnemy(10, 3f, 5, 5, 4f);

        gameObject.AddComponent<SorcererBlink>();
        enemyBehavior = GetComponent<SorcererBlink>();

        ApplyBehavior(enemyBehavior);
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        if (collision.transform.GetComponent<PlayerController>())
        {
            if (!hasMeleed)
            {
                inMeleeDistance = true;
                StartCoroutine(Melee(collision));
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        inMeleeDistance = false;
    }

    private IEnumerator Melee(Collision collision)
    {
        while (inMeleeDistance)
        { 
            hasMeleed = true;

            collision.gameObject.GetComponent<PlayerData>().playerHealth -= enemyDamage;

            yield return new WaitForSeconds(meleeDelay);
        }

        hasMeleed = false;
    }
}
