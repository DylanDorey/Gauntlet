using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [5/01/2024]
 * [Manages all level functionality and level switching]
 */

public class LevelManager : Singleton<LevelManager>
{
    //level variables
    public GameObject thiefItem;
    public GameObject thiefPrefab;
    public GameObject[] levelPrefabs;
    private GameObject level;
    public List<Vector3> playerSpawns;
    public List<GameObject> activeEnemies;
    public Vector3 thiefItemSpawn;
    private Vector3 levelSpawnPoint = Vector3.zero;

    private int levelToSpawnIndex = 0;

    public int currentLevel;

    private void OnEnable()
    {
        GameEventBus.Subscribe(GameState.startGame, StartNextLevel);
        GameEventBus.Subscribe(GameState.levelOver, StartNextLevel);
        GameEventBus.Subscribe(GameState.gameOver, ResetLevelManager);
    }

    private void OnDisable()
    {
        GameEventBus.Unsubscribe(GameState.startGame, StartNextLevel);
        GameEventBus.Unsubscribe(GameState.levelOver, StartNextLevel);
        GameEventBus.Unsubscribe(GameState.gameOver, ResetLevelManager);
    }

    /// <summary>
    /// Moves the players to the levels spawn points
    /// </summary>
    public void MovePlayers()
    {
        //for the amount of players active
        for (int index = 0; index < GameManager.Instance.players.Count; index++)
        {
            //store the player into a variable
            GameObject player = GameManager.Instance.players[index];

            //move that player to the spawn index position
            player.transform.position = playerSpawns[index];
        }
    }

    /// <summary>
    /// Initializes the next level for the game
    /// </summary>
    public void InitializeLevel()
    {
        //clear the last level of all enemies remaining
        ClearLevel();

        //increase the current level
        currentLevel++;

        //set the level text
        UIManager.Instance.levelText.text = currentLevel.ToString();

        //if there is level already active
        if(level != null)
        {
            //destroy it
            Destroy(level);
        }

        //spawn in the next level
        level = Instantiate(levelPrefabs[levelToSpawnIndex], levelSpawnPoint, Quaternion.identity);

        //clear the player spawns list
        playerSpawns.Clear();

        //set player spawns
        for (int index = 0; index < levelPrefabs[levelToSpawnIndex].gameObject.transform.GetChild(0).childCount; index++)
        {
            //add the new player spawns to the new player spawns list
            playerSpawns.Add(levelPrefabs[levelToSpawnIndex].gameObject.transform.GetChild(0).transform.GetChild(index).position);
        }

        //set thief item spawn
        thiefItemSpawn = levelPrefabs[levelToSpawnIndex].transform.GetChild(1).position;

        //if the level is greater than 1
        if (currentLevel > 1)
        {
            //spawn the thief after a random amount of time
            Invoke("SpawnThief", Random.Range(15f, 45f));
        }

        //increase the level spawn index
        levelToSpawnIndex++;
    }

    /// <summary>
    /// Starts the next level of the game
    /// </summary>
    public void StartNextLevel()
    {
        //initialize the level and move the players
        InitializeLevel();
        MovePlayers();

        //if the thief stolen item is not empty
        if (thiefItem != null)
        {
            //spawn it
            SpawnThiefItem();
        }
    }

    /// <summary>
    /// Clears the level of all previous enemies
    /// </summary>
    public void ClearLevel()
    {
        //for all of the enemies in the active enemies list
        foreach (GameObject enemy in activeEnemies)
        {
            //destroy them
            Destroy(enemy);
        }

        //clear the list
        activeEnemies.Clear();
    }

    /// <summary>
    /// Spawns the stolen thief item at the start of the next level
    /// </summary>
    private void SpawnThiefItem()
    {
        //spawn the stolen item at the thief item spawn point on the level
        Instantiate(thiefItem, thiefItemSpawn, Quaternion.identity);

        //set the thief item to null
        thiefItem = null;
    }

    /// <summary>
    /// Spawns the thief on the level
    /// </summary>
    private void SpawnThief()
    {
        //spawn the thief
        Instantiate(thiefPrefab, thiefItemSpawn, Quaternion.identity);
    }

    /// <summary>
    /// Resets the level manager variables
    /// </summary>
    public void ResetLevelManager()
    {
        thiefItem = null;
        levelToSpawnIndex = 0;
        currentLevel = 0;
    }
}
