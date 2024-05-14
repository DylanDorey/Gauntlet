using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/12/2024]
 * [Plays any sound that is sent to it]
 */

public class AudioManager : Singleton<AudioManager>
{
    private List<AudioClip> audioList;

    // Start is called before the first frame update
    void Start()
    {
        //initialize a new list of audio clips
        audioList = new List<AudioClip>();

        //StartCoroutine(PlaySounds());
    }

    private void Update()
    {
        //if the audio list has more than 0 elements
        if (audioList.Count > 0)
        {
            //play the sounds in it
            PlaySound();
        }
    }

    /// <summary>
    /// Adds a sound to the queue of sounds to be played
    /// </summary>
    /// <param name="incomingSound"> the sound that needs to be played </param>
    /// <returns> new list of updated sounds to play </returns>
    public List<AudioClip> AddToSoundQueue(AudioClip incomingSound)
    {
        //add the incoming sound to the audioList
        audioList.Add(incomingSound);

        //return the updated list
        return audioList;
    }

    /// <summary>
    /// plays the sounds in the list of sounds
    /// </summary>
    private void PlaySound()
    {
        //for each audio clip in the audio list
        for (int index = 0; index < audioList.Count; index++)
        {
            //set the audio sources clip to the next audio clip in the audio list
            GetComponent<AudioSource>().clip = audioList[index];

            //play the audio clip
            GetComponent<AudioSource>().Play();

            //remove the audio clip from the audio list
            audioList.Remove(audioList[index]);
        }
    }
}
