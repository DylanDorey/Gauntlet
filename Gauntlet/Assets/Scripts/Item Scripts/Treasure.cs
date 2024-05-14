using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/22/2024]
 * [Awards the player with points]
 */

public class Treasure : Item
{
    //pickup audio clip
    public AudioClip pickupSound;

    private void Start()
    {
        //intialize the item stats
        InitializeItem(ItemType.Treasure, 0, 100);
    }

    public override void OnCollisionEnter(Collision collision)
    {
        //pass points and health
        base.OnCollisionEnter(collision);

        //if the collided object is a player
        if (collision.gameObject.GetComponent<PlayerData>())
        {
            //play the pickup sound and set the treasure's active to false
            AudioManager.Instance.AddToSoundQueue(pickupSound);
            gameObject.SetActive(false);
        }
    }
}
