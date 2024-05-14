using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/10/2024]
 * [Stores all player data related to number values, such as stats]
 */

public class PlayerData : MonoBehaviour
{
    //player base valuies
    public int playerHealth;
    public int playerScore;
    public float playerMagic;
    public int playerArmor;
    public float playerSpeed;

    //the rate health ticks down
    [Range(1f, 5f)]
    public float healthTickRate;

    //booleans for PlayerData
    public bool hasMelee;
    public bool hasKey;
    public bool hasPotion;

    private void Start()
    {
        //start decreasing health on spawn
        StartHealthTick();
    }

    /// <summary>
    /// Initializes all player data values
    /// </summary>
    /// <param name="health">players health</param>
    /// <param name="score">players score</param>
    /// <param name="magic">players magic stat</param>
    /// <param name="armor">players armor stat</param>
    /// <param name="speed">players speed</param>
    /// <param name="isMelee">if the player has a melee ability or not</param>
    public void InitializePlayerData(int health, int score, float magic, int armor, float speed, bool isMelee)
    {
        //initialize values
        playerHealth = health;
        playerScore = score;
        playerMagic = magic;
        playerArmor = armor;
        playerSpeed = speed;
        hasMelee = isMelee;
    }

    /// <summary>
    /// Takes health away from player whenever taking damage
    /// </summary>
    /// <param name="damage"> the incoming damage </param>
    /// <returns> the players adjusted health after taking damage </returns>
    public float TakeDamage(int damage)
    {
        //remove the damage value from the players health divided by the players armor amount
        playerHealth -= damage/playerArmor;

        //store the player controller component in a variable
        PlayerController playerController = GetComponent<PlayerController>();

        //switch on that player controller component
        switch (playerController.characterType)
        {
            //if warrior
            case CharacterType.Warrior:
                //play the warrior hurt sound
                AudioManager.Instance.AddToSoundQueue(playerController.warriorAudioClips[2]);
                break;

            //if valkyrie
            case CharacterType.Valkyrie:
                //play the valkyrie hurt sound
                AudioManager.Instance.AddToSoundQueue(playerController.valkyrieAudioClips[2]);
                break;

            //if wizard
            case CharacterType.Wizard:
                //play the wizard hurt sound
                AudioManager.Instance.AddToSoundQueue(playerController.wizardAudioClips[1]);
                break;

            //if elf
            case CharacterType.Elf:
                //play the elf hurt sound
                AudioManager.Instance.AddToSoundQueue(playerController.elfAudioClips[1]);
                break;
        }

        //if the players health is less than or equal to 0
        if(playerHealth <= 0)
        {
            //if the game has more than 1 player active
            if(GameManager.Instance.players.Count > 1)
            {
                //remove that player from the list of players and destroy the game object
                GameManager.Instance.players.Remove(gameObject);
                Destroy(gameObject);
            }
            else
            {
                //otherwise remove the player from the list and publish the game over event
                GameManager.Instance.players.Remove(gameObject);
                GameEventBus.Publish(GameState.gameOver);
                Destroy(gameObject);
            }
        }

        //return the players adjusted health
        return playerHealth;
    }

    /// <summary>
    /// removes 1 health from the player
    /// </summary>
    /// <returns> the players health tick rate </returns>
    private IEnumerator HealthTick()
    {
        while (true)
        {
            //remove 1 health
            playerHealth -= 1;

            //wait the health tick rate
            yield return new WaitForSeconds(healthTickRate);
        }
    }

    /// <summary>
    /// Starts the health tick coroutine
    /// </summary>
    public void StartHealthTick()
    {
        //start health drain system
        StartCoroutine(HealthTick());
    }


    /// <summary>
    /// Stops the health tick coroutine
    /// </summary>
    public void StopHealthTick()
    {
        //stop health drain system
        StopCoroutine(HealthTick());
    }
}
