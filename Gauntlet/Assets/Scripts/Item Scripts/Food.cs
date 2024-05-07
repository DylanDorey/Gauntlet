using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Item
{
    private void Start()
    {
        InitializeItem(ItemType.Food, 100f, 0);
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        if (collision.gameObject.GetComponent<PlayerData>())
        {
            gameObject.SetActive(false);
        }
    }
}
