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
    public GameObject characterPanels;
    public GameObject keySlots;
    public GameObject potionSlots;

    //Item prefabs
    public GameObject keyPrefab;
    public GameObject bluePotionPrefab;
    public GameObject orangePotionPrefab;
    public GameObject[] itemsArray;

    public bool keyInventoryFull = false;
    public bool potionInventoryFull = false;

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
        if (item.GetComponent<Key>())
        {
            PickupKey(item);
        }

        if (item.GetComponent<Item>().itemType == ItemType.Potion)
        {
            PickupPotion(item);
        }
    }

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
                    keySlot.hasKey = true;
                    keySlot.GetComponent<Image>().sprite = keySlot.keyImage;
                    GetComponent<PlayerData>().hasKey = true;
                    break;
                }
                else if (keySlot.hasKey && index == 5)
                {
                    keyInventoryFull = true;
                }
            }
        }
    }

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
                    if (potion.GetComponent<Potion>().isDestructable)
                    {
                        potionSlot.GetComponent<Image>().sprite = potionSlot.bluePotionImage;
                    }
                    else
                    {
                        potionSlot.GetComponent<Image>().sprite = potionSlot.orangePotionImage;
                    }

                    potionSlot.hasPotion = true;

                    potionSlot.itemBehavior = potion.GetComponent<Potion>();

                    GetComponent<PlayerData>().hasPotion = true;
                    break;
                }
                else if(potionSlot.hasPotion && index == 3)
                {
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
            //reference to potion slot script
            KeySlot currentKeySlot = keySlots.transform.GetChild(index).gameObject.GetComponent<KeySlot>();

            if (currentKeySlot.hasKey && index == 5)
            {
                currentKeySlot.hasKey = false;
                currentKeySlot.GetComponent<Image>().sprite = null;

                if (keyInventoryFull)
                {
                    keyInventoryFull = false;
                }

                break;
            }

            KeySlot nextKeySlot = keySlots.transform.GetChild(index + 1).gameObject.GetComponent<KeySlot>();

            if (currentKeySlot.hasKey && nextKeySlot.hasKey == false)
            {
                currentKeySlot.hasKey = false;
                currentKeySlot.GetComponent<Image>().sprite = null;

                if (index == 0)
                {
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

            if (currentPotionSlot.hasPotion && index == 3)
            {
                currentPotionSlot.hasPotion = false;
                currentPotionSlot.GetComponent<Image>().sprite = null;
                currentPotionSlot.itemBehavior = null;

                if (potionInventoryFull)
                {
                    potionInventoryFull = false;
                }

                break;
            }

            PotionSlot nextPotionSlot = potionSlots.transform.GetChild(index + 1).gameObject.GetComponent<PotionSlot>();

            if (currentPotionSlot.hasPotion && nextPotionSlot.hasPotion == false)
            {
                currentPotionSlot.hasPotion = false;
                currentPotionSlot.GetComponent<Image>().sprite = null;
                currentPotionSlot.itemBehavior = null;

                if (index == 0)
                {
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
        characterPanels = GameObject.FindGameObjectWithTag("characterPanels");

        switch (gameObject.GetComponent<PlayerController>().character)
        {
            case CharacterType.Warrior:
                keySlots = characterPanels.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject;
                potionSlots = characterPanels.transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).gameObject;
                break;
            case CharacterType.Valkyrie:
                keySlots = characterPanels.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject;
                potionSlots = characterPanels.transform.GetChild(1).transform.GetChild(0).transform.GetChild(1).gameObject;
                break;
            case CharacterType.Wizard:
                keySlots = characterPanels.transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).gameObject;
                potionSlots = characterPanels.transform.GetChild(2).transform.GetChild(0).transform.GetChild(1).gameObject;
                break;
            case CharacterType.Elf:
                keySlots = characterPanels.transform.GetChild(3).transform.GetChild(0).transform.GetChild(0).gameObject;
                potionSlots = characterPanels.transform.GetChild(3).transform.GetChild(0).transform.GetChild(1).gameObject;
                break;
        }
    }
}
