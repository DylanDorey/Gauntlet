using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/10/2024]
 * [Stores all player data related to number values, such as stats]
 */

//various base player states
public enum PlayerEvent
{
    //OnSpawn,
    OnDeath
}

public class PlayerData : MonoBehaviour
{
    public int playerHealth;
    public int playerScore;
    public float playerMagic;
    public int playerArmor;
    public float playerSpeed;

    [Range(1f, 5f)]
    public float healthTickRate;

    public bool hasMelee;
    public bool hasKey;
    public bool hasPotion;

    private void OnEnable()
    {
        //PlayerEventBus.Subscribe(PlayerEvent.OnSpawn, StartHealthTick);
    }

    private void OnDisable()
    {
        //PlayerEventBus.Subscribe(PlayerEvent.OnSpawn, StopHealthTick);
    }

    private void Start()
    {
        StartHealthTick();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializePlayerData(int health, int score, float magic, int armor, float speed, bool isMelee)
    {
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
    /// <returns></returns>
    public float TakeDamage(int damage)
    {
        //remove the damage value from the players health, then return the players new health
        playerHealth -= damage/playerArmor;

        PlayerController playerController = GetComponent<PlayerController>();
        switch (playerController.characterType)
        {
            case CharacterType.Warrior:
                AudioManager.Instance.AddToSoundQueue(playerController.warriorAudioClips[2]);
                break;
            case CharacterType.Valkyrie:
                break;
            case CharacterType.Wizard:
                break;
            case CharacterType.Elf:
                break;
            default:
                break;
        }

        return playerHealth;
    }

    /// <summary>
    /// removes 1 health from the player
    /// </summary>
    /// <returns> the players health </returns>
    private IEnumerator HealthTick()
    {
        while (true)
        {
            //remove 1 health
            playerHealth -= 1;

            //if (playerHealth <= 0 && GameManager.Instance.isPlaying)
            //{
            //    GameEventBus.Publish(GameState.gameOver);
            //    GameManager.Instance.isPlaying = false;
            //}

            yield return new WaitForSeconds(healthTickRate);
        }
    }

    public void StartHealthTick()
    {
        //start health drain system
        StartCoroutine(HealthTick());
    }

    public void StopHealthTick()
    {
        //stop health drain system
        StopCoroutine(HealthTick());
    }
}
