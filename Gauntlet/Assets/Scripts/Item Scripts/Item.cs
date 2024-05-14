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
    //reference to itemType enum, the item's heal amount, and the amount of points the item is worth
    public ItemType itemType;
    public int healAmount;
    public int pointAmount;

    /// <summary>
    /// Initialize all item stats
    /// </summary>
    /// <param name="type"> the type of item it is</param>
    /// <param name="heal"> the amount of healing it does </param>
    /// <param name="points"> the amount of points it awards </param>
    public void InitializeItem(ItemType type, int heal, int points)
    {
        itemType = type;
        healAmount = heal;
        pointAmount = points;
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        //if the collided object is a player
        if (collision.gameObject.GetComponent<PlayerData>())
        {
            //pass the point and health balues to the player
            PassPoints(collision);
            PassHealth(collision);
        }
    }

    /// <summary>
    /// Passes item's points to the player
    /// </summary>
    /// <param name="collision"> the collided object </param>
    public void PassPoints(Collision collision)
    {
        //add points to the players score
        collision.gameObject.GetComponent<PlayerData>().playerScore += pointAmount;
    }

    /// <summary>
    /// Passes item's healing amount to the player
    /// </summary>
    /// <param name="collision"> the collided object </param>
    public void PassHealth(Collision collision)
    {
        //heal the player for the amount of healing the item is worth
        collision.gameObject.GetComponent<PlayerData>().playerHealth += healAmount;
    }
}
