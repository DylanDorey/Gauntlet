using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/22/2024]
 * [Base class for all items like doors, food, treasure, potions, and keys]
 */

//enum for the type of item the object is
public enum ItemType
{
    Door,
    Treasure,
    Key,
    Food,
    Potion
}

public class Item : MonoBehaviour
{
    //feference to itemType enum, the items heal amount, and the amount of points the item is worth
    public ItemType itemType;
    public int healAmount;
    public int pointAmount;

    public void InitializeItem(ItemType type, int heal, int points)
    {
        itemType = type;
        healAmount = heal;
        pointAmount = points;
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerData>())
        {
            PassPoints(collision);
            PassHealth(collision);
        }
    }

    public void PassPoints(Collision collision)
    {
        collision.gameObject.GetComponent<PlayerData>().playerScore += pointAmount;
    }

    public void PassHealth(Collision collision)
    {
        collision.gameObject.GetComponent<PlayerData>().playerHealth += healAmount;
    }
}
