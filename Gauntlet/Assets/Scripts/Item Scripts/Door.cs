using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/24/2024]
 * [A door that can be opened with keys]
 */

public class Door : Item
{
    public AudioClip openSound;

    private void Start()
    {
        //initialize the door item
        InitializeItem(ItemType.Door, 0, 0);
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        //if the colliding object is a player
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            //open the door if the player has keys
            OpenDoor(collision);
        }
    }

    /// <summary>
    /// Opens the door if the player has a key
    /// </summary>
    /// <param name="collision"> the colliding game object </param>
    private void OpenDoor(Collision collision)
    {
        //if the player has at least 1 key
        if (collision.gameObject.GetComponent<PlayerData>().hasKey)
        {
            //remove the key from the player's inventory, and open the door
            collision.gameObject.GetComponent<InventoryManager>().RemoveKeyOnUse();
            AudioManager.Instance.AddToSoundQueue(openSound);
            gameObject.SetActive(false);
        }
    }
}
