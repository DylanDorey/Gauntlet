using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item, IItemBehavior
{
    public bool isDestructable;
    public int potionDamage;

    IItemBehavior itemBehavior;
    private PlayerData _playerData;

    public SphereCollider aoeCollider;

    private void Awake()
    {
        InitializeItem(ItemType.Potion, 0f, 100);
        itemBehavior = this;
    }

    public override void OnCollisionEnter(Collision collision)
    {
        if (isDestructable)
        {
            if (collision.gameObject.CompareTag("Projectile"))
            {
                ApplyBehavior(itemBehavior);
            }
        }

        if (collision.transform.GetComponent<PlayerController>())
        {
            _playerData = collision.gameObject.GetComponent<PlayerData>();
            collision.transform.GetComponent<InventoryManager>().PickupItem(gameObject);
        }
    }

    public void InitializePotion(bool destructable, int damage)
    {
        isDestructable = destructable;
        potionDamage = damage;
    }

    public void ApplyBehavior(IItemBehavior behavior)
    {
        behavior.Behavior(_playerData);
    }

    public void Behavior(PlayerData playerData)
    {
        UsePotion(playerData);
    }

    public void UsePotion(PlayerData playerData)
    {
        Instantiate(aoeCollider, playerData.transform.position, Quaternion.identity);
    }
}
