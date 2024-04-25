using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //determines if the inventory is full or not
    public bool inventoryFull = false;

    //inventory slot references
    public GameObject characterPanels;
    public GameObject keySlots;

    //Item prefabs
    public GameObject keyPrefab;
    public GameObject bluePotionPrefab;
    public GameObject orangePotionPrefab;
    public GameObject[] itemsArray;

    //Item abilities/elements
    public IItemBehavior[] itemAbilities;
    //public BluePotion bluePotionAbility;
    //public OrangePotion orangePotionAbility;

    private void Start()
    {
        //arrays for the item game objects and the items abilities/uses
        itemsArray = new GameObject[] { keyPrefab, bluePotionPrefab, orangePotionPrefab };
        //itemAbilities = new IItemBehavior[] { bluePotionAbility, orangePotionAbility };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"> the item that is being picked up </param>
    public void PickupItem(GameObject item)
    {
        if (item.GetComponent<Key>())
        {
            PickupKey(item);
        }

        //switch (item.GetComponent<Item>().itemType)
        //{
        //    case ItemType.Key:
        //        PickupKey(item);
        //        break;
        //    case ItemType.Potion:
        //        break;
        //    default:
        //        break;
        //}

        if (item.GetComponent<Item>().itemType == ItemType.Potion)
        {

        }

        //for (int index = 0; index < inventorySlots.transform.childCount; index++)
        //{
        //    //reference to inventory slot script
        //    KeySlot keySlot = keySlots.transform.GetChild(index).gameObject.GetComponent<InventorySlot>();

        //    //if the slot does not have an item in it
        //    if (inventorySlot.hasItem == false)
        //    {
        //        //get the inventory slot image of the game object's image that the player just picked up
        //        inventorySlot.slotImage = item.GetComponent<Item>().itemImage;

        //        //set the inventory slot image to the game object's image that the player just picked up
        //        inventorySlot.SetInventoryImage();

        //        //set the game object in the inventory slot to the gameobject the player just picked up
        //        for (int index2 = 0; index2 < itemsArray.Length; index2++)
        //        {
        //            //if the items name matches the items in the items array
        //            if (item.name == itemsArray[index2].name)
        //            {
        //                //assign the items Use interface function to the inventory slot
        //                inventorySlot.itemUse = itemAbilities[index2];
        //                break;
        //            }
        //        }

        //        //set hasItem to true for the index slot
        //        inventorySlot.hasItem = true;

        //        //show what item the player picked up
        //        StartCoroutine(UIManager.Instance.ItemPickup(item.name));

        //        break;
        //    } //if all the slots are full
        //    else if (inventorySlot.hasItem && index == 4)
        //    {
        //        inventoryFull = true;

        //        //DISPLAY ERROR MESSAGE SAYING INVENTORY IS FULL
        //        StartCoroutine(UIManager.Instance.ItemPickup(null));
        //    }
        //}
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
            KeySlot keySlot = keySlots.transform.GetChild(index).gameObject.GetComponent<KeySlot>();

            //if the slot does not have a key in it
            if (keySlot.hasKey == false)
            {
                //if its the first slot
                if (index == 0)
                {
                    //set the child slot's has key to false, image to null, and player's hasKey variable to false
                    keySlot.hasKey = false;
                    keySlot.GetComponent<Image>().sprite = null;
                    GetComponent<PlayerData>().hasKey = false;
                }
                else
                {
                    //otherwise set the previous child's image to null and set has key on key slot to false
                    keySlots.transform.GetChild(index - 1).GetComponent<Image>().sprite = null;
                    keySlots.transform.GetChild(index - 1).gameObject.GetComponent<KeySlot>().hasKey = false;
                }
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
                break;
            case CharacterType.Valkyrie:
                keySlots = characterPanels.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject;
                break;
            case CharacterType.Wizard:
                keySlots = characterPanels.transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).gameObject;
                break;
            case CharacterType.Elf:
                keySlots = characterPanels.transform.GetChild(3).transform.GetChild(0).transform.GetChild(0).gameObject;
                break;
        }
    }

    ///// <summary>
    ///// Removes the item from the player's inventory when it is used
    ///// </summary>
    ///// <param name="slotIndex"> the slot the item is being removed from </param>
    //public void RemoveItemOnUse(int slotIndex)
    //{
    //    //reference to slot image component and inventory slot script
    //    Image slotImage = inventorySlots.transform.GetChild(slotIndex).gameObject.GetComponent<Image>();
    //    InventorySlot slot = inventorySlots.transform.GetChild(slotIndex).gameObject.GetComponent<InventorySlot>();

    //    //set all used/filled values to empty/false
    //    slot.hasItem = false;
    //    slotImage.sprite = null;
    //    slot.slotImage = null;
    //    slot.itemUse = null;

    //    //if the inventory was full
    //    if (inventoryFull == true)
    //    {
    //        //set it to not full
    //        inventoryFull = false;
    //    }
    //}
}
