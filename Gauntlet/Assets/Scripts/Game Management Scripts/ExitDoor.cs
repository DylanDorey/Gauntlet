using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public AudioClip levelChangeMusic;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<PlayerController>())
        {
            GameEventBus.Publish(GameState.levelOver);
            AudioManager.Instance.AddToSoundQueue(levelChangeMusic);
        }
    }
}
