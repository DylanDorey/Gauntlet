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
    public AudioClip pickupSound;

    private void Start()
    {
        InitializeItem(ItemType.Treasure, 0, 100);
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        if (collision.gameObject.GetComponent<PlayerData>())
        {
            AudioManager.Instance.AddToSoundQueue(pickupSound);
            gameObject.SetActive(false);
        }
    }
}
