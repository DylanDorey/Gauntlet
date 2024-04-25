using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/24/2024]
 * [The key inventory slot]
 */

public class KeySlot : MonoBehaviour
{
    public bool hasKey;
    public Sprite keyImage;

    private void Start()
    {
        GetComponent<Image>().sprite = null;
    }
}
