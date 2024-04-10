using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/10/2024]
 * [This will manage all game functions such as initializing, starting, returning to menu, and quiting]
 */

//the various game states
public enum GameState
{
    mainMenu,
    startGame
    //add more game states
}

public class GameManager : Singleton<GameManager>
{
    public int testInt = 1;

    public override void Awake()
    {
        //initialize singleton
        base.Awake();


    }

    private void Start()
    {
        //start the game in the main menu by publishing the menu game event
        GameEventBus.Publish(GameState.mainMenu);
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    /// <summary>
    /// This will intialize all game elements for Gauntlet
    /// </summary>
    private void InitializeGame()
    {

    }

    /// <summary>
    /// This will start the game Gauntlet from the main menu
    /// </summary>
    public void StartGame()
    {
        //publish the startGame game event
        GameEventBus.Publish(GameState.startGame);
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
