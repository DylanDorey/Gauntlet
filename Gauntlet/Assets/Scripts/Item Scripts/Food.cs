using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Item
{
    public AudioClip pickupSound;
    public AudioClip destroySound;

    private void Start()
    {
        InitializeItem(ItemType.Food, 100f, 0);
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        if (collision.gameObject.GetComponent<PlayerData>())
        {
            AudioManager.Instance.AddToSoundQueue(pickupSound);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Projectile"))
        {
            AudioManager.Instance.AddToSoundQueue(destroySound);
            Destroy(gameObject);
        }
    }
}
