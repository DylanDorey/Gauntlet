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
    //potion variables
    public bool isDestructable;

    public IItemBehavior itemBehavior;
    public PlayerData _playerData;

    public SphereCollider aoeCollider;

    public AudioClip usePotionSound;
    public AudioClip pickupSound;

    private void Awake()
    {
        //initialize the potion item
        InitializeItem(ItemType.Potion, 0, 0);
        itemBehavior = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if the colliding game object is a player
        if (other.transform.GetComponent<PlayerController>())
        {
            //set the player data to the player data that collided
            _playerData = other.gameObject.GetComponent<PlayerData>();

            //allow the player to pickup the potion
            other.transform.GetComponent<InventoryManager>().PickupItem(gameObject);

            //if the players potion inventory is not full
            if (other.transform.GetComponent<InventoryManager>().potionInventoryFull == false)
            {
                //play the pickup sound and destroy the pickup
                AudioManager.Instance.AddToSoundQueue(pickupSound);
                Destroy(gameObject);
            }
        }

        //if the potion is destructable
        if (isDestructable)
        {
            //if the other game object is a projectile
            if (other.gameObject.CompareTag("Projectile"))
            {
                //activate the potions behavior on the ground
                ApplyBehavior(itemBehavior);

                //destroy the projectile and the potion
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// Initializes the potions destructibility bool
    /// </summary>
    /// <param name="destructable"> if the potion is destructable or not </param>
    public void InitializePotion(bool destructable)
    {
        isDestructable = destructable;
    }

    /// <summary>
    /// Applies the potions behavior to the player data that has it
    /// </summary>
    /// <param name="behavior"></param>
    public void ApplyBehavior(IItemBehavior behavior)
    {
        behavior.Behavior(_playerData);
    }

    /// <summary>
    /// Attaches the potions behavior to the potion and the player that has it
    /// </summary>
    /// <param name="playerData"></param>
    public void Behavior(PlayerData playerData)
    {
        UsePotion(playerData);
    }

    /// <summary>
    /// Allows the player to use a potion they have
    /// </summary>
    /// <param name="playerData">the player that has the potion </param>
    public void UsePotion(PlayerData playerData)
    {
        //if the potion has not been picked up
        if (_playerData == null)
        {
            //spawn the AOE collider on its position and scale the AOE bubble at a fixed rate
            Collider AOE = Instantiate(aoeCollider, transform.position, Quaternion.identity);
            AOE.GetComponent<AOECollider>().scaleFactor = new Vector3(3f, 3f, 3f);
        }
        else
        {
            //spawn the AOE collider on the players position and scale the AOE bubble by the players magic stat
            Collider AOE = Instantiate(aoeCollider, playerData.transform.position, Quaternion.identity);
            AOE.GetComponent<AOECollider>().scaleFactor = new Vector3(playerData.playerMagic, playerData.playerMagic, playerData.playerMagic);

            //set the used by variable in the AOE collider to pass points for death's death
            AOE.GetComponent<AOECollider>().usedBy = playerData;
        }

        //play the potion use sound
        AudioManager.Instance.AddToSoundQueue(usePotionSound);
    }
}
