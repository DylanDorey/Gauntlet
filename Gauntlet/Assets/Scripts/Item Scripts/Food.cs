using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/22/2024]
 * [A food item that heals the player]
 */

public class Food : Item
{
    //food pickup and destroy sound
    public AudioClip pickupSound;
    public AudioClip destroySound;

    private void Start()
    {
        //intialize the food's stats
        InitializeItem(ItemType.Food, 100, 0);
    }

    public override void OnCollisionEnter(Collision collision)
    {
        //pass point and health
        base.OnCollisionEnter(collision);

        //if the collided game object is a player
        if (collision.gameObject.GetComponent<PlayerData>())
        {
            //play the pickup sound and destroy the game object
            AudioManager.Instance.AddToSoundQueue(pickupSound);
            Destroy(gameObject);
        }

        //if the collided game object is a projectile
        if (collision.gameObject.CompareTag("Projectile"))
        {
            //play the destroy sound and destroy the game object
            AudioManager.Instance.AddToSoundQueue(destroySound);
            Destroy(gameObject);
        }
    }
}
