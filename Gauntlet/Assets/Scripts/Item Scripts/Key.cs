using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item
{
    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        //InventoryManager.Instance.PickupItem(gameObject);
    }
}
