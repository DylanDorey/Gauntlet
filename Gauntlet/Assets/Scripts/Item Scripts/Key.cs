using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item
{
    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        collision.gameObject.GetComponent<InventoryManager>().PickupItem(gameObject);

        Destroy(gameObject);
    }
}
