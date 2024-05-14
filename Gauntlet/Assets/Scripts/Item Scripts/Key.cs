using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/24/2024]
 * [A key that can be stored for future use to open doors]
 */

public class Key : Item
{
    //pickup sound
    public AudioClip pickupSound;

    private void Start()
    {
        //initialize the items stats
        InitializeItem(ItemType.Key, 0, 100);
    }

    public override void OnCollisionEnter(Collision collision)
    {
        //pass points and health
        base.OnCollisionEnter(collision);

        //tell the inventory manager a key has been picked up
        collision.gameObject.GetComponent<InventoryManager>().PickupItem(gameObject);

        //if the key inventory is not full
        if (collision.transform.GetComponent<InventoryManager>().keyInventoryFull == false)
        {
            //play the pickup sound and destroy the game object
            AudioManager.Instance.AddToSoundQueue(pickupSound);
            Destroy(gameObject);
        }
    }
}
