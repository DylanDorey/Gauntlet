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
    //key slot variables
    public bool hasKey;
    public Sprite keyImage;

    private void Start()
    {
        //check the key slots to update
        StartCoroutine(CheckSlotImage());
    }

    /// <summary>
    /// Checks if the key slots have changed
    /// </summary>
    /// <returns>time between checking again</returns>
    private IEnumerator CheckSlotImage()
    {
        while (true)
        {
            //if the slot has a key
            if (hasKey == true)
            {
                //set the image to the key image
                GetComponent<Image>().sprite = keyImage;
            }
            else
            {
                //set the image to null
                GetComponent<Image>().sprite = null;
            }

            //check every 0.1 seconds
            yield return new WaitForSeconds(0.1f);
        }
    }
}
