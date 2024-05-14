using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/19/2024]
 * [A door that allows the player to start the next level]
 */

public class ExitDoor : MonoBehaviour
{
    //level change music audio clip
    public AudioClip levelChangeMusic;

    private void OnCollisionEnter(Collision collision)
    {
        //if a player collides with the exit door
        if (collision.transform.GetComponent<PlayerController>())
        {
            //start the next level with a slight delay
            StartCoroutine(NextLevelDelay());
        }
    }

    /// <summary>
    /// Loads the next level after 2 seconds of colliding with the door
    /// </summary>
    /// <returns></returns>
    private IEnumerator NextLevelDelay()
    {
        for (int index = 0; index < 1; index++)
        {
            //play the level change music
            AudioManager.Instance.AddToSoundQueue(levelChangeMusic);

            //wait 2 seconds
            yield return new WaitForSeconds(2f);
        }

        //publish the level over state
        GameEventBus.Publish(GameState.levelOver);
    }
}
