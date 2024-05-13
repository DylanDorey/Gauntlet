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
            StartCoroutine(NextLevelDelay());
        }
    }

    private IEnumerator NextLevelDelay()
    {
        for (int index = 0; index < 1; index++)
        {
            AudioManager.Instance.AddToSoundQueue(levelChangeMusic);
            yield return new WaitForSeconds(2f);
        }

        GameEventBus.Publish(GameState.levelOver);
    }
}
