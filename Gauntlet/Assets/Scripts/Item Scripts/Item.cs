using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enum for the type of item the object is
public enum ItemType
{
    Treasure,
    Key,
    Food,
    Potion
}

public class Item : MonoBehaviour
{
    //feference to itemType enum, the items heal amount, and the amount of points the item is worth
    public ItemType itemType;
    public float healAmount;
    public int pointAmount;

    public void InitializeItem(ItemType type, float heal, int points)
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
        GetComponent<Collider>().gameObject.GetComponent<PlayerData>().playerScore += pointAmount;
    }

    public void PassHealth(Collision collision)
    {
        GetComponent<Collider>().gameObject.GetComponent<PlayerData>().playerHealth += healAmount;
    }
}
