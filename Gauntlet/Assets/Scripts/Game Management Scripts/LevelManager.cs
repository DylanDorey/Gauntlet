using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public GameObject thiefItem;
    public GameObject[] levelPrefabs;
    public Vector3[] playerSpawns;
    public Vector3 thiefItemSpawn;
    private Vector3 levelSpawnPoint = Vector3.zero;

    private int levelToSpawnIndex = 0;

    private void OnEnable()
    {
        GameEventBus.Subscribe(GameState.levelOver, StartNextLevel);
    }

    private void OnDisable()
    {
        GameEventBus.Unsubscribe(GameState.levelOver, StartNextLevel);
    }

    public void MovePlayers()
    {
        for (int index = 0; index < GameManager.Instance.players.Count; index++)
        {
            GameObject player = GameManager.Instance.players[index];

            player.transform.position = playerSpawns[index];
        }
    }

    /// <summary>
    /// Gets the next level to spawn in
    /// </summary>
    public void InitializeLevel()
    {
        Instantiate(levelPrefabs[levelToSpawnIndex], levelSpawnPoint, Quaternion.identity);

        //set player spawns
        for (int index = 0; index < 4; index++)
        {
            playerSpawns[index] = levelPrefabs[levelToSpawnIndex].transform.GetChild(0).transform.GetChild(index).position;
        }

        //set thief item spawn
        thiefItemSpawn = levelPrefabs[levelToSpawnIndex].transform.GetChild(1).position;

        //increase the level spawn index
        levelToSpawnIndex++;
    }

    public void StartNextLevel()
    {
        InitializeLevel();
        MovePlayers();

        if (thiefItem != null)
        {
            SpawnThiefItem();
        }
    }

    public void ClearLevel()
    {

    }

    private void SpawnThiefItem()
    {
        Instantiate(thiefItem, thiefItemSpawn, Quaternion.identity);

        thiefItem = null;
    }
}
