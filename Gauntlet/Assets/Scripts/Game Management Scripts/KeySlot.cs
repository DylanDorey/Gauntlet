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
        StartCoroutine(CheckSlotImage());
    }

    private IEnumerator CheckSlotImage()
    {
        while (true)
        {
            if (hasKey == true)
            {
                GetComponent<Image>().sprite = keyImage;
            }
            else
            {
                GetComponent<Image>().sprite = null;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
