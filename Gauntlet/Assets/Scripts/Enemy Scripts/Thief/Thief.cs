using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Enemy
{
    public AudioClip thiefTone;
    private int targetPointValue;

    public bool hasStolen = false;
    public bool hasDied = false;

    public override void Start()
    {
        base.Start();

        InitializeEnemy(500, 8f, 10, 10f, 50f);

        enemyBehavior = GetComponent<Steal>();

        //initialize the target pos to a random player
        targetPos = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<PlayerController>())
        {
            GetComponent<Steal>().playerInventory = collision.transform.GetComponent<InventoryManager>();
            GetComponent<Steal>().playerData = collision.transform.GetComponent<PlayerData>();

            collision.transform.GetComponent<PlayerData>().playerHealth -= enemyDamage;

            if (!hasStolen)
            {
                ApplyBehavior(enemyBehavior);
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);
                StartCoroutine(Flee());
            }
        }

        if (enemyHealth <= 0)
        {
            if (collision.transform.GetComponent<Axe>() || collision.transform.GetComponent<Fireball>() || collision.transform.GetComponent<Sword>())
            {
                UIManager.Instance.warrior.gameObject.GetComponent<PlayerData>().playerScore += PassPoints();
                OnDeath();
            }
        }
    }

    public override void OnDeath()
    {
        if (hasStolen)
        {
            Instantiate(GetComponent<Steal>().stolenItem, transform.position, Quaternion.identity);
        }

        hasDied = true;

        base.OnDeath();
    }

    public IEnumerator Flee()
    {
        targetPos = GameObject.FindGameObjectWithTag("Exit").gameObject.transform.position;
        AudioManager.Instance.AddToSoundQueue(thiefTone);

        for (int index = 0; index < 1; index++)
        {
            yield return new WaitForSeconds(5f);
        }

        hasDied = false;

        if (GetComponent<Steal>().stolenItem != null)
        {
            LevelManager.Instance.thiefItem = GetComponent<Steal>().stolenItem;
        }

        gameObject.SetActive(false);
    }
}
