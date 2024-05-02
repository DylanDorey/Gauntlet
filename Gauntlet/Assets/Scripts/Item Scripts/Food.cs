using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Item
{
    private void Start()
    {
        InitializeItem(ItemType.Food, 100f, 0);
    }
}
