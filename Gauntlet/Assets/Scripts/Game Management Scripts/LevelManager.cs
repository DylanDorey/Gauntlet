using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
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

    private void Update()
    {
        UIManager.Instance.levelText.text = currentLevel.ToString();
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
        ClearLevel();

        currentLevel++;

        if(level != null)
        {
            Destroy(level);
        }

        level = Instantiate(levelPrefabs[levelToSpawnIndex], levelSpawnPoint, Quaternion.identity);

        playerSpawns.Clear();

        //set player spawns
        for (int index = 0; index < levelPrefabs[levelToSpawnIndex].gameObject.transform.GetChild(0).childCount; index++)
        {
            playerSpawns.Add(levelPrefabs[levelToSpawnIndex].gameObject.transform.GetChild(0).transform.GetChild(index).position);
        }

        //set thief item spawn
        thiefItemSpawn = levelPrefabs[levelToSpawnIndex].transform.GetChild(1).position;

        if(currentLevel > 1)
        {
            Invoke("SpawnThief", Random.Range(15f, 45f));
        }

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
        foreach (GameObject enemy in activeEnemies)
        {
            activeEnemies.Remove(enemy);
            Destroy(enemy);
        }

        activeEnemies.Clear();
    }

    private void SpawnThiefItem()
    {
        Instantiate(thiefItem, thiefItemSpawn, Quaternion.identity);

        thiefItem = null;
    }

    private void SpawnThief()
    {
        Instantiate(thiefPrefab, thiefItemSpawn, Quaternion.identity);
    }

    public void ResetLevelManager()
    {
        thiefItem = null;
        levelToSpawnIndex = 0;
        currentLevel = 0;
    }
}
