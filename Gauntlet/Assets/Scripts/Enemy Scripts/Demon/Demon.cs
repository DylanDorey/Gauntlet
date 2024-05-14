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
    public GameObject fireballPrefab;
    public Transform shootingPoint;
    public float shootDelay = 2f;
    public float meleeDelay = 2f;
    public bool hasMeleed;
    public AudioClip shootSound;
    public AudioClip meleeSound;
    public bool canShoot;
    public Collision playerCollision;

    public override void Start()
    {
        base.Start();

        InitializeEnemy(10, 2f, 5, 5, 10f);
        gameObject.AddComponent<DemonMelee>();
        enemyBehavior = GetComponent<DemonMelee>();
    }

    private void FixedUpdate()
    {
        if (isAggro)
        {
            FindNearestPlayer();
            Move();
            if (canShoot)
            {
                StartCoroutine(FireballDelay());
            }
        }

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (enemyHealth <= 0)
        {
            if (collision.transform.GetComponent<Axe>() || collision.transform.GetComponent<Fireball>() || collision.transform.GetComponent<Sword>() || collision.transform.GetComponent<Arrow>())
            {
                UIManager.Instance.warrior.gameObject.GetComponent<PlayerData>().playerScore += PassPoints();
            }
        }

        if (collision.transform.GetComponent<PlayerController>())
        {
            if (!hasMeleed)
            {
                playerCollision = collision;
                ApplyBehavior(enemyBehavior);
            }
        }
    }

    void FindNearestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        float minDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;

        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestPlayer = player;
            }
        }

        if (nearestPlayer != null && minDistance <= enemyRadius)
        {
            targetPos = nearestPlayer.transform.position;
        }
        else
        {
            targetPos = Vector3.zero;
        }
    }

    IEnumerator FireballDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootDelay);

        Vector3 directionToPlayer = (targetPos - shootingPoint.position).normalized;

        // Create and throw the projectile
        GameObject projectile = Instantiate(fireballPrefab, shootingPoint.position, Quaternion.identity);
        projectile.GetComponent<Rock>().moveDirection = transform.forward;
        AudioManager.Instance.AddToSoundQueue(shootSound);

        canShoot = true;
    }

}