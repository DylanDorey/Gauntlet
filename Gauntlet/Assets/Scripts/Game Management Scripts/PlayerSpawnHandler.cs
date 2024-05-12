using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnHandler : Singleton<PlayerSpawnHandler>
{
    private PlayerInputManager playerInputManager;

    public Gamepad warriorGamepad;
    public Gamepad valkyrieGamepad;

    private void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
    }

    private void Update()
    {
        UpdatePrefab();
    }

    public void UpdatePrefab()
    {
        switch (GameManager.Instance.characters)
        {
            case 0:
                playerInputManager.playerPrefab = GameManager.Instance.playerPrefabs[0];
                break;

            case 1:
                playerInputManager.playerPrefab = GameManager.Instance.playerPrefabs[1];
                break;

            case 2:
                playerInputManager.playerPrefab = GameManager.Instance.playerPrefabs[2];
                break;

            case 3:
                playerInputManager.playerPrefab = GameManager.Instance.playerPrefabs[3];
                break;
        }
    }
}
