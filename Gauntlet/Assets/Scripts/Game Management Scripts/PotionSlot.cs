using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionSlot : MonoBehaviour
{
    public bool hasPotion;
    public Sprite orangePotionImage;
    public Sprite bluePotionImage;
    public IItemBehavior itemBehavior;

    private void Start()
    {
        //StartCoroutine(CheckSlotImage());
    }

    private IEnumerator CheckSlotImage()
    {
        while(true)
        {
            if (hasPotion == true)
            {
                GetComponent<Image>().enabled = true;
            }
            else
            {
                GetComponent<Image>().enabled = false;
            }

            yield return new WaitForSeconds(0.2f);
        }
    }
}
