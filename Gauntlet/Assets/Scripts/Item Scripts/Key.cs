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
    private void Start()
    {
        InitializeItem(ItemType.Key, 0f, 100);
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        collision.gameObject.GetComponent<InventoryManager>().PickupItem(gameObject);

        Destroy(gameObject);
    }
}
