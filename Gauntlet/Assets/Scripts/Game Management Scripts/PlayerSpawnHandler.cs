using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [5/05/2024]
 * [A spawn handler that allows players to join in the game]
 */

public class PlayerSpawnHandler : Singleton<PlayerSpawnHandler>
{
    //reference to player input manager
    private PlayerInputManager playerInputManager;

    private void Start()
    {
        //initialize player input manager
        playerInputManager = GetComponent<PlayerInputManager>();
    }

    private void Update()
    {
        //update the next player prefab
        UpdatePrefab();
    }

    /// <summary>
    /// Updates the character prefab to spawn in
    /// </summary>
    public void UpdatePrefab()
    {
        //based on the characters playing/in use
        switch (GameManager.Instance.characters)
        {
            //if 0
            case 0:
                //set prefab to warrior
                playerInputManager.playerPrefab = GameManager.Instance.playerPrefabs[0];
                break;

            //if 1
            case 1:
                //set prefab to valkyrie
                playerInputManager.playerPrefab = GameManager.Instance.playerPrefabs[1];
                break;

            //if 2
            case 2:
                //set prefab to wizard
                playerInputManager.playerPrefab = GameManager.Instance.playerPrefabs[2];
                break;

            //if 3
            case 3:
                //set prefab to elf
                playerInputManager.playerPrefab = GameManager.Instance.playerPrefabs[3];
                break;
        }
    }
}
