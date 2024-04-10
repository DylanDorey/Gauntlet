using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/10/2024]
 * [Allows Player to move around and interact with game environment]
 */

public class PlayerController : MonoBehaviour
{
    //reference to scriptable object PlayerInput
    public PlayerInput playerActions;

    private void OnEnable()
    {
        PlayerEventBus.Subscribe(PlayerEvent.Initialization, InitializePlayerController);
    }

    private void OnDisable()
    {
        PlayerEventBus.Unsubscribe(PlayerEvent.Initialization, InitializePlayerController);
    }

    /// <summary>
    /// initializes the player controller at the start of the game
    /// </summary>
    public void InitializePlayerController()
    {
        //reference for the PlayerInput scriptable object
        playerActions = new PlayerInput(); //constructor

        //turn playerActions on
        playerActions.Enable();

        //determine which character this player will be
        //int characterToAdd = GameManager.Instance.characters;
        //switch (characterToAdd)
        //{
        //    case 0:
        //        gameObject.AddComponent<Warrior>();
        //        gameObject.AddComponent<ThrowAxe>();
        //        gameObject.AddComponent<WarriorMelee>();
        //        break;
        //    case 1:
        //        gameObject.AddComponent<Wizard>();
        //        gameObject.AddComponent<ThrowFireball>();
        //        break;
        //    case 2:
        //        gameObject.AddComponent<Valkyrie>();
        //        gameObject.AddComponent<ThrowSword>();
        //        gameObject.AddComponent<ValkyrieMelee>();
        //        break;
        //    case 3:
        //        gameObject.AddComponent<Elf>();
        //        gameObject.AddComponent<ShootArrow>();
        //        gameObject.AddComponent<ElfMelee>();
        //        break;
        //    default:
        //        break;
        //}

        //if (characterToAdd == 3)
        //{
        //    GameManager.Instance.maxCharactersInPlay = true;
        //    characterToAdd = 0;
        //}
        //else
        //{
        //    characterToAdd++;
        //}
    }

    /// <summary>
    /// Spawns in the player controller prefab at its spawn location
    /// </summary>
    public void StartPlayerController()
    {

    }
}
