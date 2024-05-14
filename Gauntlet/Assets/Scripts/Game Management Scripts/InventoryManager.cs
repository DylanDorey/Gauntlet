using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/16/2024]
 * [An inventory for the keys and potions the player can collect and store for future use]
 */

public class InventoryManager : MonoBehaviour
{
    //determines if the inventory is full or not
    public bool inventoryFull = false;

    //inventory slot references
    public GameObject keySlots;
    public GameObject potionSlots;

    //Item prefabs
    public GameObject keyPrefab;
    public GameObject bluePotionPrefab;
    public GameObject orangePotionPrefab;
    public GameObject[] itemsArray;

    //inventories full bools
    public bool keyInventoryFull = false;
    public bool potionInventoryFull = false;

    private void OnEnable()
    {
        GameEventBus.Subscribe(GameState.startGame, InitializeSlots);
    }

    private void OnDisable()
    {
        GameEventBus.Unsubscribe(GameState.startGame, InitializeSlots);
    }

    private void Start()
    {
        //arrays for the item game objects and the items abilities/uses
        itemsArray = new GameObject[] { keyPrefab, bluePotionPrefab, orangePotionPrefab };
    }

    /// <summary>
    /// Picks up an item and passes it to the correct inventory
    /// </summary>
    /// <param name="item"> the item that is being picked up </param>
    public void PickupItem(GameObject item)
    {
        //if the item is a key
        if (item.GetComponent<Key>())
        {
            //pickup the key
            PickupKey(item);
        }

        //if the item is a potion
        if (item.GetComponent<Item>().itemType == ItemType.Potion)
        {
            //pickup the potion
            PickupPotion(item);
        }
    }

    /// <summary>
    /// Picks up a key and adds it to the key inventory
    /// </summary>
    /// <param name="key"> the key being passed to the manager </param>
    private void PickupKey(GameObject key)
    {
        //if the item is a key
        if (key.GetComponent<Key>().itemType == ItemType.Key)
        {
            for (int index = 0; index < keySlots.transform.childCount; index++)
            {
                //reference to key slot script
                KeySlot keySlot = keySlots.transform.GetChild(index).gameObject.GetComponent<KeySlot>();

                //if the slot does not have an item in it
                if (keySlot.hasKey == false)
                {
                    //add it to the slot
                    keySlot.hasKey = true;
                    keySlot.GetComponent<Image>().sprite = keySlot.keyImage;
                    GetComponent<PlayerData>().hasKey = true;
                    break;
                }
                else if (keySlot.hasKey && index == 5)
                {
                    //other wise set key inventory to full
                    keyInventoryFull = true;
                }
            }
        }
    }

    /// <summary>
    /// Picks up a potion and adds it to the potion inventory
    /// </summary>
    /// <param name="potion"> the potion being passed to the manager</param>
    private void PickupPotion(GameObject potion)
    {
        //if the item is a potion
        if (potion.GetComponent<Potion>().itemType == ItemType.Potion)
        {
            for (int index = 0; index < potionSlots.transform.childCount; index++)
            {
                //reference to potion slot script
                PotionSlot potionSlot = potionSlots.transform.GetChild(index).gameObject.GetComponent<PotionSlot>();

                //if the slot does not have an item in it
                if (potionSlot.hasPotion == false)
                {
                    //if the potion is destructable
                    if (potion.GetComponent<Potion>().isDestructable)
                    {
                        //set the image to the blue potion
                        potionSlot.GetComponent<Image>().sprite = potionSlot.bluePotionImage;
                    }
                    else
                    {
                        //otherwise set the image to the orange potion
                        potionSlot.GetComponent<Image>().sprite = potionSlot.orangePotionImage;
                    }

                    //set has potion in potion slot to true
                    potionSlot.hasPotion = true;

                    //pass the potion behavior
                    potionSlot.itemBehavior = potion.GetComponent<Potion>();

                    //set has potion in playerdata to true
                    GetComponent<PlayerData>().hasPotion = true;
                    break;
                }
                else if(potionSlot.hasPotion && index == 3)
                {
                    //otherwise set potion inventory to full
                    potionInventoryFull = true;
                }
            }
        }
    }

    /// <summary>
    /// Removes a key from the key inventory
    /// </summary>
    public void RemoveKeyOnUse()
    {
        for (int index = 0; index < keySlots.transform.childCount; index++)
        {
            //reference to key slot script
            KeySlot currentKeySlot = keySlots.transform.GetChild(index).gameObject.GetComponent<KeySlot>();

            //if the current slot has a key and its the last slot
            if (currentKeySlot.hasKey && index == 5)
            {
                //set the key slot's has key to false and remove the image
                currentKeySlot.hasKey = false;
                currentKeySlot.GetComponent<Image>().sprite = null;

                //if the inventory was full
                if (keyInventoryFull)
                {
                    //set inventory to not full
                    keyInventoryFull = false;
                }

                break;
            }

            //reference to the next key slot
            KeySlot nextKeySlot = keySlots.transform.GetChild(index + 1).gameObject.GetComponent<KeySlot>();

            //if the current slot has a key and the next slot doesnt
            if (currentKeySlot.hasKey && nextKeySlot.hasKey == false)
            {
                //set the current slots has key to false and image to false
                currentKeySlot.hasKey = false;
                currentKeySlot.GetComponent<Image>().sprite = null;

                //if its the first slot
                if (index == 0)
                {
                    //set the players has key to true
                    GetComponent<PlayerData>().hasKey = false;
                }

                break;
            }
        }
    }

    /// <summary>
    /// Removes a potion from the potion inventory
    /// </summary>
    public void RemovePotionOnUse()
    {
        for (int index = 0; index < potionSlots.transform.childCount; index++)
        {
            //reference to potion slot script
            PotionSlot currentPotionSlot = potionSlots.transform.GetChild(index).gameObject.GetComponent<PotionSlot>();

            //if the current potion slot has a key and its the last slot
            if (currentPotionSlot.hasPotion && index == 3)
            {
                //remove the potion
                currentPotionSlot.hasPotion = false;
                currentPotionSlot.GetComponent<Image>().sprite = null;
                currentPotionSlot.itemBehavior = null;

                //if the potion inventory was full
                if (potionInventoryFull)
                {
                    //set it to not full
                    potionInventoryFull = false;
                }

                break;
            }

            //reference to the next potion slot
            PotionSlot nextPotionSlot = potionSlots.transform.GetChild(index + 1).gameObject.GetComponent<PotionSlot>();

            //if the current potion slot has a potion and the next potion slot doesnt
            if (currentPotionSlot.hasPotion && nextPotionSlot.hasPotion == false)
            {
                //remove the potion in the current slot
                currentPotionSlot.hasPotion = false;
                currentPotionSlot.GetComponent<Image>().sprite = null;
                currentPotionSlot.itemBehavior = null;

                //if its the first slot
                if (index == 0)
                {
                    //set the player data has potion to false
                    GetComponent<PlayerData>().hasPotion = false;
                }

                break;
            }
        }
    }

    /// <summary>
    /// Initializes the key slots game object depending on what character the player is
    /// </summary>
    public void InitializeSlots()
    {
        //based on the character's type
        switch (gameObject.GetComponent<PlayerController>().characterType)
        {
            //if warrior
            case CharacterType.Warrior:
                //set the warrior inventory slots
                GameObject warriorPanel = GameObject.Find("WarriorInventoryPanel");
                keySlots = warriorPanel.transform.GetChild(0).gameObject;
                potionSlots = warriorPanel.transform.GetChild(1).gameObject;
                break;
            //if valkyrie
            case CharacterType.Valkyrie:
                //set the valkyrie inventory slots
                GameObject valkyriePanel = GameObject.Find("ValkyrieInventoryPanel");
                keySlots = valkyriePanel.transform.GetChild(0).gameObject;
                potionSlots = valkyriePanel.transform.GetChild(1).gameObject;
                break;
            //if wizard
            case CharacterType.Wizard:
                //set the wizard inventory slots
                GameObject wizardPanel = GameObject.Find("WizardInventoryPanel");
                keySlots = wizardPanel.transform.GetChild(0).gameObject;
                potionSlots = wizardPanel.transform.GetChild(1).gameObject;
                break;
            //if elf
            case CharacterType.Elf:
                //set the elf inventory slots
                GameObject elfPanel = GameObject.Find("ElfInventoryPanel");
                keySlots = elfPanel.transform.GetChild(0).gameObject;
                potionSlots = elfPanel.transform.GetChild(1).gameObject;
                break;
        }
    }
}
