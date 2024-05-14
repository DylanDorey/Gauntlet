using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [05/03/2024]
 * [A potion that removes all enemies in a given radius]
 */

public class Potion : Item, IItemBehavior
{
    public bool isDestructable;

    public IItemBehavior itemBehavior;
    public PlayerData _playerData;

    public SphereCollider aoeCollider;

    public AudioClip usePotionSound;
    public AudioClip pickupSound;

    private void Awake()
    {
        InitializeItem(ItemType.Potion, 0, 0);
        itemBehavior = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<PlayerController>())
        {
            _playerData = other.gameObject.GetComponent<PlayerData>();
            other.transform.GetComponent<InventoryManager>().PickupItem(gameObject);

            if (other.transform.GetComponent<InventoryManager>().potionInventoryFull == false)
            {
                AudioManager.Instance.AddToSoundQueue(pickupSound);
                Destroy(gameObject);
            }
        }

        if (isDestructable)
        {
            if (other.gameObject.CompareTag("Projectile"))
            {
                ApplyBehavior(itemBehavior);

                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }

    public void InitializePotion(bool destructable)
    {
        isDestructable = destructable;
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
        if (_playerData == null)
        {
            Collider AOE = Instantiate(aoeCollider, transform.position, Quaternion.identity);
            AOE.GetComponent<AOECollider>().scaleFactor = new Vector3(3f, 3f, 3f);
        }
        else
        {
            Collider AOE = Instantiate(aoeCollider, playerData.transform.position, Quaternion.identity);
            AOE.GetComponent<AOECollider>().scaleFactor = new Vector3(playerData.playerMagic, playerData.playerMagic, playerData.playerMagic);
            AOE.GetComponent<AOECollider>().usedBy = playerData;
        }

        AudioManager.Instance.AddToSoundQueue(usePotionSound);
    }
}
