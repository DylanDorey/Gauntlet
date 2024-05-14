using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/16/2024]
 * [A potion slot that holds potion images and potion behavior]
 */

public class PotionSlot : MonoBehaviour
{
    //potion slot variables
    public bool hasPotion;
    public Sprite orangePotionImage;
    public Sprite bluePotionImage;
    public IItemBehavior itemBehavior;

    private void Start()
    {
        //StartCoroutine(CheckSlotImage());
    }

    /// <summary>
    /// Checks when to set UI images active or not
    /// </summary>
    /// <returns></returns>
    private IEnumerator CheckSlotImage()
    {
        while(true)
        {
            //if the slot has a potion
            if (hasPotion == true)
            {
                //enable the image
                GetComponent<Image>().enabled = true;
            }
            else
            {
                //otherwise tunr the image off
                GetComponent<Image>().enabled = false;
            }

            //wait 0.2 seconds before checking again
            yield return new WaitForSeconds(0.2f);
        }
    }
}
