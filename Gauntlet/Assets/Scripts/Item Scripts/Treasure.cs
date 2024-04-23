using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : Item
{
    private void Start()
    {
        InitializeItem(ItemType.Treasure, 0f, 100);
    }
}
