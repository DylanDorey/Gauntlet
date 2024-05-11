using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/10/2024]
 * [This will manage all game functions such as initializing, starting, returning to menu, and quiting]
 */

//the various game states
public enum GameState
{
    mainMenu,
    startGame,
    levelOver,
    gameOver
}

public class GameManager : Singleton<GameManager>
{
    public int characters = 0;
    public List<GameObject> players;
    public bool isPlaying;

    public GameObject[] playerPrefabs;

    private void Start()
    {
        //start the game in the main menu by publishing the menu game event
        GameEventBus.Publish(GameState.mainMenu);
    }

    /// <summary>
    /// This will start the game Gauntlet from the main menu
    /// </summary>
    public void StartGame()
    {
        //publish the startGame game event
        GameEventBus.Publish(GameState.startGame);
        isPlaying = true;
    }

    /// <summary>
    /// This will send the user back to the main menu
    /// </summary>
    public void ReturnToMenu()
    {
        //publish the menu game event
        GameEventBus.Publish(GameState.mainMenu);
    }

    /// <summary>
    /// This will allow the user to close/quit Gauntlet
    /// </summary>
    public void QuitGame()
    {
        //quit the application
        Application.Quit();
    }
}
