using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeySlot : MonoBehaviour
{
    public bool hasKey;
    public Sprite keyImage;

    private void Start()
    {
        GetComponent<Image>().sprite = null;
    }
}
